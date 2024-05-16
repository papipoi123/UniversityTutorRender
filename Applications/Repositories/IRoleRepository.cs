using Domain.Entities;

namespace Applications.Repositories
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<Role?> GetRoleInfo(int id);
    }
}
