using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class CourseMajorService : ICourseMajorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseMajorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> CreateCourseMajor(CourseMajorViewModel courseMajorViewModel)
        {
            var courseMajorObj = _mapper.Map<CourseMajor>(courseMajorViewModel);
            await _unitOfWork.CourseMajorRepository.CreateAsync(courseMajorObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                return new Response(HttpStatusCode.OK, "Create success");
            }
            return new Response(HttpStatusCode.BadRequest, "Create fail");
        }

        public async Task<Response> GetAllCourseMajor(int pageIndex = 0, int pageSize = 10)
        {
            var courseMajorObj = await _unitOfWork.CourseMajorRepository.ToPagination(pageIndex, pageSize);
            var result = _mapper.Map<Pagination<CourseMajorViewModel>>(courseMajorObj);
            if (courseMajorObj.Items.Count() < 1)
            {
                return new Response(HttpStatusCode.NoContent, "No CourseMajor Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> GetCourseMajorInfor(int id)
        {
            var courseMajorObj = await _unitOfWork.CourseMajorRepository.GetEntityByIdAsync(id);
            var result = _mapper.Map<CourseMajorViewModel>(courseMajorObj);
            if (courseMajorObj is null)
            {
                return new Response(HttpStatusCode.NoContent, "No CourseMajor Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> RemoveCourseMajor(int id)
        {
            var courseMajorObj = await _unitOfWork.CourseMajorRepository.GetEntityByIdAsync(id);
            if (courseMajorObj is not null)
            {
                _unitOfWork.CourseMajorRepository.DeleteAsync(courseMajorObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Fail");
        }

        public async Task<Response> UpdateCourseMajor(int id, CourseMajorViewModel courseMajorViewModel)
        {
            var courseMajorObj = await _unitOfWork.CourseMajorRepository.GetEntityByIdAsync(id);
            if (courseMajorObj is not null)
            {
                _mapper.Map(courseMajorViewModel, courseMajorObj);
                _unitOfWork.CourseMajorRepository.UpdateAsync(courseMajorObj);
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
