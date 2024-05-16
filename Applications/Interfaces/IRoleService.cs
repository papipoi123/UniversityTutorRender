using Applications.Commons;
using Applications.ViewModels;

namespace Applications.Interfaces
{
    public interface IRoleService
    {
        Task<Response> GetRoleInfor(int id);
        Task<Response> GetAllRole(int pageIndex = 0, int pageSize = 10);
        Task<Response> CreateRole(RoleViewModel model);
        Task<Response> UpdateRole(int id, RoleViewModel model);
        Task<Response> RemoveRole(int id);
    }
}
