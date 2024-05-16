using Applications.Commons;
using Applications.Interfaces;
using Applications.Repositories;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(AppDbContext context, ICurrentTimeService currentTime, IClaimsServices claimsServices) : base(context, currentTime, claimsServices)
        {
        }

        public async Task<Pagination<Transaction>> GetByTransactionStatus(TransactionStatus status, int pageIndex = 0, int pageSize = 10)
        {
            var itemCount = await _dbSet.Where(x => x.TransactionStatus == status).CountAsync();
            var items = await _dbSet.Where(x => x.TransactionStatus == status).Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .AsNoTracking()
                                    .ToListAsync();

            var result = new Pagination<Transaction>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItemsCount = itemCount,
                Items = items,
            };
            return result;
        }
        public async Task<Pagination<Transaction>> GetByTransactionByUserId(int UserId, int pageIndex = 0, int pageSize = 10)
        {
            var itemCount = await _dbSet.Where(x => x.Wallet.User.Id == UserId).CountAsync();
            var items = await _dbSet.Where(x => x.Wallet.User.Id == UserId).Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .AsNoTracking()
                                    .ToListAsync();

            var result = new Pagination<Transaction>()
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
