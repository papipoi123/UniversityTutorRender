using Applications.Commons;
using Applications.ViewModels;

namespace Applications.Interfaces
{
    public interface ITutorService
    {
        Task<Response> GetTutorInfor(int id);
        Task<Response> GetAllTutor(int pageIndex = 0, int pageSize = 10);
        Task<Response> CreateTutor(TutorViewModel tutorViewModel);
        Task<Response> UpdateTutor(int id, UpdateTutorViewModel tutorViewModel);
        Task<Response> RemoveTutor(int id);
    }
}
