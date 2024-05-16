using Applications.Interfaces;
using Applications.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context, ICurrentTimeService currentTime, IClaimsServices claimsServices) : base(context, currentTime, claimsServices)
        {
        }
        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _dbSet.Where(x => x.IsDeleted == false).Include(x => x.OrderDetails).ToListAsync();
        }

        public async Task<List<Order>> GetByStudentId(int id)
        {
            return await _dbSet.Where(x => x.IsDeleted == false && x.StudentId == id).Include(x => x.OrderDetails).ToListAsync();
        }

        //public async Task<List<Order>> GetByCourseId(int id)
        //{
        //    int coursecheckid;
        //    var result = await _dbSet.Where(x => x.IsDeleted == false).ToListAsync();
        //    foreach (var item in result)
        //    {
        //        foreach (var item2 in item.OrderDetails)
        //        {
        //            coursecheckid = item2.TeachingCourseId;
        //        }
        //    }
        //    return await _dbSet.Where(x => x.IsDeleted == false && coursecheckid == id).Include(x => x.OrderDetails).ToListAsync();
        //}
    }
}
