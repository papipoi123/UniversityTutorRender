using Applications.Commons;
using Applications.ViewModels;

namespace Applications.Interfaces
{
    public interface IAdminService
    {
        Task<Response> GetAdminInfor(int id);
        Task<Response> GetAllAdmin(int pageIndex = 0, int pageSize = 10);
        Task<Response> CreateAdmin(AdminViewModel model);
        Task<Response> UpdateAdmin(int id, AdminViewModel model);
        Task<Response> RemoveAdmin(int id);
    }
}
