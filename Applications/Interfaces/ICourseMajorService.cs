using Applications.Commons;
using Applications.ViewModels;

namespace Applications.Interfaces
{
    public interface ICourseMajorService
    {
        Task<Response> GetCourseMajorInfor(int id);
        Task<Response> GetAllCourseMajor(int pageIndex = 0, int pageSize = 10);
        Task<Response> CreateCourseMajor(CourseMajorViewModel courseMajorViewModel);
        Task<Response> UpdateCourseMajor(int id, CourseMajorViewModel courseMajorViewModel);
        Task<Response> RemoveCourseMajor(int id);
    }
}
