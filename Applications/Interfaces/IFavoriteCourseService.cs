using Applications.Commons;

namespace Applications.Interfaces
{
    public interface IFavoriteCourseService
    {
        Task<Response> GetAllFavoriteCourse(int pageIndex = 0, int pageSize = 10);
        Task<Response> CreateFavoriteCourse(int studentId, int teachingCourseId);
        Task<Response> DeleteFavoriteCourse(int studentId, int teachingCourseId);
    }
}
