using Applications.Commons;
using Applications.Interfaces;
using Applications.Utils;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


       

        public async Task<Response> GetAllReport(int pageIndex = 0, int pageSize = 10)
        {
            var reportObj = await _unitOfWork.ReportRepository.ToPagination(pageIndex, pageSize);
            var result = _mapper.Map<Pagination<ReportViewModel>>(reportObj);
            if (reportObj.Items.Any())
            {
                return new Response(HttpStatusCode.OK, "Success", result);
            }
            return new Response(HttpStatusCode.NoContent, "No Report Found");
        }

        public async Task<Response> GetReportInfor(int id)
        {
            var reportObj = await _unitOfWork.ReportRepository.GetEntityByIdAsync(id);
            var result = _mapper.Map<ReportViewModel>(reportObj);
            if (reportObj is null)
            {
                return new Response(HttpStatusCode.NoContent, "No Report Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> RemoveReport(int id)
        {
            var reportObj = await _unitOfWork.ReportRepository.GetEntityByIdAsync(id);
            if (reportObj is not null)
            {
                _unitOfWork.ReportRepository.DeleteAsync(reportObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Fail");
        }

        public async Task<Response> CreateReport(ReportViewModel reportViewModel)
        {
            var userId = await _unitOfWork.UserRepository.GetEntityByIdAsync(reportViewModel.UserId);
            if (userId is null)
            {
                return new Response(HttpStatusCode.NotFound, "User id not found");

            }
            var reportObj = _mapper.Map<Report>(reportViewModel);
            await _unitOfWork.ReportRepository.CreateAsync(reportObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                return new Response(HttpStatusCode.OK, "Create success");
            }
            return new Response(HttpStatusCode.BadRequest, "Create fail");
        }

        public async Task<Response> UpdateReport(int id, ReportViewModel reportViewModel)
        {
            var reportObj = await _unitOfWork.ReportRepository.GetEntityByIdAsync(id);
            if (reportObj is not null)
            {
                _mapper.Map(reportViewModel, reportObj);
                _unitOfWork.ReportRepository.UpdateAsync(reportObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Fail");
        }
    }
}
