using Applications.Commons;
using Applications.Interfaces;
using Applications.Repositories;
using Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DbSet<T> _dbSet;
        private readonly ICurrentTimeService _currentTime;
        private readonly IClaimsServices _claimsServices;

        public GenericRepository(AppDbContext context, ICurrentTimeService currentTime, IClaimsServices claimsServices)
        {
            _dbSet = context.Set<T>();
            _currentTime = currentTime;
            _claimsServices = claimsServices;
        }

        public virtual async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task CreateRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public virtual void DeleteAsync(T entity)
        {
            entity.IsDeleted = true;
            _dbSet.Update(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.Where(x => x.IsDeleted == false).AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetEntityByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public virtual async Task<Pagination<T>> ToPagination(int pageIndex = 0, int pageSize = 10)
        {
            var itemCount = await _dbSet.Where(x => x.IsDeleted == false).CountAsync();
            var items = await _dbSet.Where(x => x.IsDeleted == false).Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .AsNoTracking()
                                    .ToListAsync();

            var result = new Pagination<T>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItemsCount = itemCount,
                Items = items,
            };
            return result;
        }

        public virtual void UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void UpdateRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }
    }
}
