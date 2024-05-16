using Applications.Commons;
using Domain.Entities;
using Domain.Enums;

namespace Applications.Repositories
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        Task<Pagination<Transaction>> GetByTransactionStatus(TransactionStatus status, int pageIndex = 0, int pageSize = 10);
        Task<Pagination<Transaction>> GetByTransactionByUserId(int UserId, int pageIndex = 0, int pageSize = 10);
    }
}
