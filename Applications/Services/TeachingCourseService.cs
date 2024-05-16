using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class TeachingCourseService : ITeachingCourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsServices _claimsServices;
        public TeachingCourseService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IClaimsServices claimsServices)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsServices = claimsServices;
        }


        public async Task<Response> GetAllTeachingCourse()
        {
            var teachingCourseObj = await _unitOfWork.TeachingCourseRepository.GetListTeachingCourse();

            foreach (var item in teachingCourseObj)
            {
                var rating = await _unitOfWork.RatingRepository.getByTeachingCourseId(item.Id);
                if (rating.Count() > 0)
                {
                    var avgRating = _unitOfWork.RatingRepository.getAvgrating(item.Id);
                    item.RatingStar = avgRating;
                }
                else
                {
                    item.RatingStar = 0;
                }
            }
            _unitOfWork.TeachingCourseRepository.UpdateRangeAsync(teachingCourseObj);
            await _unitOfWork.SaveChangeAsync();

            var result = _mapper.Map<List<GetTeachingCourseViewModel>>(teachingCourseObj);
            if (!teachingCourseObj.Any())
            {
                return new Response(HttpStatusCode.NotFound, "No Teaching Course Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> GetTeachingCourseInfor(int id)
        {
            var teachingCourseObj = await _unitOfWork.TeachingCourseRepository.GetListTeachingCourse(id);
            foreach (var item in teachingCourseObj)
            {
                var rating = await _unitOfWork.RatingRepository.getByTeachingCourseId(item.Id);
                if (rating.Count() > 0)
                {
                    var avgRating = _unitOfWork.RatingRepository.getAvgrating(item.Id);
                    item.RatingStar = avgRating;
                }
                else
                {
                    item.RatingStar = 0;
                }
            }
            _unitOfWork.TeachingCourseRepository.UpdateRangeAsync(teachingCourseObj);
            await _unitOfWork.SaveChangeAsync();
            var result = _mapper.Map<List<GetTeachingCourseViewModel>>(teachingCourseObj);
            if (teachingCourseObj is null)
            {
                return new Response(HttpStatusCode.NotFound, "No Teaching Course Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> RemoveTeachingCourse(int id)
        {
            var teachingCourseObj = await _unitOfWork.TeachingCourseRepository.GetEntityByIdAsync(id);
            if (teachingCourseObj is not null)
            {

                _unitOfWork.TeachingCourseRepository.DeleteAsync(teachingCourseObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Fail");
        }

        public async Task<Response> UpdateTeachingCourse(int id, TeachingCourseViewModel teachingCourseViewModel)
        {
            var teachingCourseObj = await _unitOfWork.TeachingCourseRepository.GetEntityByIdAsync(id);
            if (teachingCourseObj is null)
                return new Response(HttpStatusCode.BadRequest, "Fail");

            _mapper.Map(teachingCourseViewModel, teachingCourseObj);
            _unitOfWork.TeachingCourseRepository.UpdateAsync(teachingCourseObj);
            await _unitOfWork.SaveChangeAsync();

            return new Response(HttpStatusCode.Accepted, "Success");
        }
        public async Task<Response> CreateTeachingCourse(TeachingCourseViewModel teachingCourseViewModel)
        {
            var teachingCourseObj = _mapper.Map<TeachingCourse>(teachingCourseViewModel);
            await _unitOfWork.TeachingCourseRepository.CreateAsync(teachingCourseObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                return new Response(HttpStatusCode.Created, "Create success");
            }
            return new Response(HttpStatusCode.BadRequest, "Create fail");
        }

        public async Task<Response> FilterTeachingCourse(FilterTeachingCourseRequest request, int pageIndex = 0, int pageSize = 10)
        {
            var teachingCourseObj = await _unitOfWork.TeachingCourseRepository.Filter(request);

            foreach (var item in teachingCourseObj.Items)
            {
                var rating = await _unitOfWork.RatingRepository.getByTeachingCourseId(item.Id);
                if (rating.Count() > 0)
                {
                    var avgRating = _unitOfWork.RatingRepository.getAvgrating(item.Id);
                    item.RatingStar = avgRating;
                }
                else
                {
                    item.RatingStar = 0;
                }
            }
            _unitOfWork.TeachingCourseRepository.UpdateRangeAsync(teachingCourseObj.Items);
            await _unitOfWork.SaveChangeAsync();

            var result = teachingCourseObj;
            if (teachingCourseObj.Items.Count() < 1)
            {
                return new Response(HttpStatusCode.NoContent, "No Teaching Course Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }
    }
}
