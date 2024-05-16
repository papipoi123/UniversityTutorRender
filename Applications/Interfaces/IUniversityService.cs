using Applications.Commons;
using Applications.ViewModels;

namespace Applications.Interfaces
{
    public interface IUniversityService
    {
        Task<Response> CreateUniversity(UniversityViewModel universityViewModel);
        Task<Response> GetAllUniversity(int pageIndex = 0, int pageSize = 10);
        Task<Response> GetUniversityInfor(int id);
        Task<Response> RemoveUniversity(int id);
        Task<Response> UpdateUniversity(int id, UniversityViewModel universityViewModel);
    }
}