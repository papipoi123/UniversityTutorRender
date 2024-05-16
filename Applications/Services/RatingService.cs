using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class RatingService : IRatingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RatingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> CreateRating(RatingViewModel model)
        {
            var studentId = await _unitOfWork.StudentRepository.GetEntityByIdAsync(model.StudentId);
            if (studentId is null)
            {
                return new Response(HttpStatusCode.NotFound, "Not found student id");
            }

            var teachingCourseId = await _unitOfWork.TeachingCourseRepository.GetEntityByIdAsync(model.TeachingCourseId);
            if (teachingCourseId is null)
            {
                return new Response(HttpStatusCode.NotFound, "Not found teaching course id");
            }

            var ratingObj = _mapper.Map<Rating>(model);
            await _unitOfWork.RatingRepository.CreateAsync(ratingObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                return new Response(HttpStatusCode.OK, "Create success");
            }
            return new Response(HttpStatusCode.BadRequest, "Create fail");
        }

        public async Task<Response> GetAllRating(int pageIndex = 0, int pageSize = 10)
        {
            var ratingObj = await _unitOfWork.RatingRepository.ToPagination(pageIndex, pageSize);
            var result = _mapper.Map<Pagination<GetRatingViewModel>>(ratingObj);
            if (ratingObj.Items.Count() < 1)
            {
                return new Response(HttpStatusCode.NoContent, "No Rating Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> GetRatingInfor(int id)
        {
            var ratingObj = await _unitOfWork.RatingRepository.GetEntityByIdAsync(id);
            var result = _mapper.Map<GetRatingViewModel>(ratingObj);
            if (ratingObj is null)
            {
                return new Response(HttpStatusCode.NoContent, "No Rating Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> RemoveRating(int id)
        {
            var ratingObj = await _unitOfWork.RatingRepository.GetEntityByIdAsync(id);
            if (ratingObj is not null)
            {
                _unitOfWork.RatingRepository.DeleteAsync(ratingObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Fail");
        }

        public async Task<Response> UpdateRating(int id, RatingViewModel model)
        {
            var ratingObj = await _unitOfWork.RatingRepository.GetEntityByIdAsync(id);
            if (ratingObj is not null)
            {
                var studentId = await _unitOfWork.StudentRepository.GetEntityByIdAsync(model.StudentId);
                if (studentId is null)
                {
                    return new Response(HttpStatusCode.NotFound, "Not found student id");
                }

                var teachingCourseId = await _unitOfWork.TeachingCourseRepository.GetEntityByIdAsync(model.TeachingCourseId);
                if (teachingCourseId is null)
                {
                    return new Response(HttpStatusCode.NotFound, "Not found teaching course id");
                }
                _mapper.Map(model, ratingObj);
                _unitOfWork.RatingRepository.UpdateAsync(ratingObj);
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
