using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class FavoriteCourseService : IFavoriteCourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FavoriteCourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response> CreateFavoriteCourse(int studentId, int teachingCourseId)
        {
            var favoriteCourseObj = await _unitOfWork.FavoriteCourseRepository.GetByStudentIdAndTeachingCourseId(studentId, teachingCourseId);
            if (favoriteCourseObj is not null)
            {
                return new Response(HttpStatusCode.BadRequest, "Favorite Course existed!");
            }
            var studentObj = await _unitOfWork.StudentRepository.GetEntityByIdAsync(studentId);
            var teachingCourseObj = await _unitOfWork.TeachingCourseRepository.GetEntityByIdAsync(teachingCourseId);
            if (studentObj is not null && teachingCourseObj is not null)
            {
                var favoriteCourse = new FavoriteCourse
                {
                    Student = studentObj,
                    TeachingCourse = teachingCourseObj
                };
                await _unitOfWork.FavoriteCourseRepository.CreateAsync(favoriteCourse);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Create success");
                }
                return new Response(HttpStatusCode.BadRequest, "Create fail");
            }
            return new Response(HttpStatusCode.NotFound, "Student Id or Teaching Course Id not found!");
        }

        public async Task<Response> DeleteFavoriteCourse(int studentId, int teachingCourseId)
        {
            var favoriteCourseObj = await _unitOfWork.FavoriteCourseRepository.GetByStudentIdAndTeachingCourseId(studentId, teachingCourseId);
            if (favoriteCourseObj is not null)
            {
                _unitOfWork.FavoriteCourseRepository.DeleteAsync(favoriteCourseObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Fail");
        }

        public async Task<Response> GetAllFavoriteCourse(int pageIndex = 0, int pageSize = 10)
        {
            var favoriteCourseObj = await _unitOfWork.FavoriteCourseRepository.ToPagination(pageIndex, pageSize);
            var result = _mapper.Map<Pagination<GetFavoriteCourseViewModel>>(favoriteCourseObj);
            if (favoriteCourseObj.Items.Count() < 1)
            {
                return new Response(HttpStatusCode.NoContent, "No Favorite Course Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }
    }
}
