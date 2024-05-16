using Applications.Commons;
using Domain.Entities;

namespace Applications.Repositories
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        Task<Pagination<Admin>?> GetAllAdmin(int pageIndex = 0, int pageSize = 10);
        Task<Admin?> GetAdminById(int id);
    }
}
