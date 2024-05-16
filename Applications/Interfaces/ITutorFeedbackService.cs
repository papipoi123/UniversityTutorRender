using Applications.Commons;
using Applications.ViewModels;

namespace Applications.Interfaces
{
    public interface ITutorFeedbackService
    {
        Task<Response> GetTutorFeedbackInfor(int id);
        Task<Response> GetAllTutorFeedback(int pageIndex = 0, int pageSize = 10);
        Task<Response> CreateTutorFeedback(TutorFeedbackViewModel tutorFeedbackViewModel);
        Task<Response> UpdateTutorFeedback(int id, TutorFeedbackViewModel tutorFeedbackViewModel);
        Task<Response> RemoveTutorFeedback(int id);
    }
}
