using Applications.Interfaces;
using Applications.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext context, ICurrentTimeService currentTime, IClaimsServices claimsServices) : base(context, currentTime, claimsServices)
        {
        }

        public async Task<Role?> GetRoleInfo(int id)
        {
            var role = await _dbSet.Include(x => x.Users).FirstOrDefaultAsync(x => x.Id == id);
            return role;
        }
    }
}
