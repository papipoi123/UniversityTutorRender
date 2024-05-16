using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class WeeklyTimeService : IWeeklyTimeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsServices _claimsServices;
        public WeeklyTimeService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IClaimsServices claimsServices)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsServices = claimsServices;
        }


        public async Task<Response> GetAllWeeklyTime(int pageIndex = 0, int pageSize = 10)
        {
            var weeklyTimeObj = await _unitOfWork.WeeklyTimeRepository.ToPagination(pageIndex, pageSize);
            var result = _mapper.Map<Pagination<GetWeeklyTimeViewModel>>(weeklyTimeObj);
            if (!weeklyTimeObj.Items.Any())
            {
                return new Response(HttpStatusCode.NotFound, "No Weekly Time Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> GetWeeklyTimeInfor(int id)
        {
            var weeklyTimeObj = await _unitOfWork.WeeklyTimeRepository.GetEntityByIdAsync(id);
            var result = _mapper.Map<GetWeeklyTimeViewModel>(weeklyTimeObj);
            if (weeklyTimeObj is null)
            {
                return new Response(HttpStatusCode.NotFound, "No Weekly Time Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> RemoveWeeklyTime(int id)
        {
            var weeklyTimeObj = await _unitOfWork.WeeklyTimeRepository.GetEntityByIdAsync(id);
            if (weeklyTimeObj is not null)
            {

                _unitOfWork.WeeklyTimeRepository.DeleteAsync(weeklyTimeObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Fail");
        }

        public async Task<Response> UpdateWeeklyTime(int id, WeeklyTimeViewModel weeklyTimeViewModel)
        {
            var weeklyTimeObj = await _unitOfWork.WeeklyTimeRepository.GetEntityByIdAsync(id);
            if (weeklyTimeObj is null)
                return new Response(HttpStatusCode.BadRequest, "Fail");

            _mapper.Map(weeklyTimeViewModel, weeklyTimeObj);
            _unitOfWork.WeeklyTimeRepository.UpdateAsync(weeklyTimeObj);
            await _unitOfWork.SaveChangeAsync();

            return new Response(HttpStatusCode.Accepted, "Success");
        }
        public async Task<Response> CreateWeeklyTime(WeeklyTimeViewModel weeklyTimeViewModel)
        {
            var weeklyTimeObj = _mapper.Map<WeeklyTime>(weeklyTimeViewModel);
            await _unitOfWork.WeeklyTimeRepository.CreateAsync(weeklyTimeObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                return new Response(HttpStatusCode.Created, "Create success");
            }
            return new Response(HttpStatusCode.BadRequest, "Create fail");
        }
    }
}
