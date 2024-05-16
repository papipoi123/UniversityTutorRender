using Applications.Commons;
using Applications.ViewModels;

namespace Applications.Interfaces
{
    public interface IStudentService
    {
        Task<Response> GetStudentInfor(int id);
        Task<Response> GetAllStudent(int pageIndex = 0, int pageSize = 10);
        Task<Response> CreateStudent(StudentViewModel studentViewModel);
        Task<Response> UpdateStudent(int id, UpdateStudentViewModel studentViewModel);
        Task<Response> RemoveStudent(int id);
    }
}
