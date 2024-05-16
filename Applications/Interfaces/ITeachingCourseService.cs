using Applications.Commons;
using Applications.ViewModels;
using Domain.Entities;

namespace Applications.Interfaces
{
    public interface ITeachingCourseService
    {
        Task<Response> CreateTeachingCourse(TeachingCourseViewModel teachingCourseViewModel);
        Task<Response> GetAllTeachingCourse();
        Task<Response> GetTeachingCourseInfor(int id);
        Task<Response> RemoveTeachingCourse(int id);
        Task<Response> UpdateTeachingCourse(int id, TeachingCourseViewModel teachingCourseViewModel);
        Task<Response> FilterTeachingCourse(FilterTeachingCourseRequest request, int pageIndex = 0, int pageSize = 10);
    }
}