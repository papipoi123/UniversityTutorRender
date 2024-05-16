using Applications.Commons;
using Applications.Interfaces;
using Applications.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(AppDbContext context, ICurrentTimeService currentTime, IClaimsServices claimsServices) : base(context, currentTime, claimsServices)
        {
        }

        public async Task<Admin?> GetAdminById(int id)
        {
            return await _dbSet.Include(x => x.User).FirstOrDefaultAsync(x => x.User.Id == id && x.IsDeleted == false);
        }

        public async Task<Pagination<Admin>?> GetAllAdmin(int pageIndex = 0, int pageSize = 10)
        {
            var itemCount = await _dbSet.Where(x => x.IsDeleted == false).CountAsync();
            var items = await _dbSet.Include(x => x.User)
                                    .Where(x => x.IsDeleted == false)
                                    .Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .AsNoTracking()
                                    .ToListAsync();

            var result = new Pagination<Admin>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItemsCount = itemCount,
                Items = items,
            };
            return result;
        }
    }
}
