using Applications.Commons;
using Applications.ViewModels;

namespace Applications.Interfaces
{
    public interface IOnlineClassService
    {
        Task<Response> GetAllOnlineClass(int pageIndex = 0, int pageSize = 10);
        Task<Response> CreateOnlineClass(int studentId, int teachingCourseId);
        Task<Response> DeleteOnlineClass(int studentId, int teachingCourseId);
    }
}
