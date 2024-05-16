using Applications.Commons;
using Domain.Base;

namespace Applications.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task CreateRangeAsync(IEnumerable<T> entities);
        void UpdateAsync(T entity);
        void UpdateRangeAsync(IEnumerable<T> entities);
        void DeleteAsync(T entity);
        Task<T> GetEntityByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<Pagination<T>> ToPagination(int pageIndex = 0, int pageSize = 10);
    }
}
