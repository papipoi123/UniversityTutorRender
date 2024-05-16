using Applications.Commons;
using Applications.ViewModels;

namespace Applications.Interfaces
{
    public interface IUserService
    {
        Task<Response> Login(LoginViewModel loginViewModel);
        Task<Response> GetUserInfor(int id);
        Task<Response> GetAllUser(int pageIndex = 0, int pageSize = 10);
        Task<Response> CreateUser(UserViewModel userViewModel);
        Task<Response> Register(RegisterViewModel registerViewModel);
        Task<Response> UpdateUser(int id, UserViewModel userViewModel);
        Task<Response> RemoveUser(int id);
        Task<Response> ResetPassword(ResetPasswordRequest request);
        Task<Response> RegisterTutor(RegisTutorModel model);
    }
}
