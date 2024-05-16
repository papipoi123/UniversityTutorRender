using Applications.Commons;
using Applications.Interfaces;
using Applications.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context, ICurrentTimeService currentTime, IClaimsServices claimsServices) : base(context, currentTime, claimsServices)
        {
        }

        public async Task<Pagination<Student?>> GetAllStudent(int pageIndex = 0, int pageSize = 10)
        {
            var itemCount = await _dbSet.Where(x => x.IsDeleted == false).CountAsync();
            var items = await _dbSet.Include(x => x.User)
                                    .Where(x => x.IsDeleted == false)
                                    .Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .AsNoTracking()
                                    .ToListAsync();

            var result = new Pagination<Student>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItemsCount = itemCount,
                Items = items,
            };
            return result;
        }

        public async Task<Student?> GetStudentInfo(int id)
        {
            var student = await _dbSet.Include(x => x.User).FirstOrDefaultAsync(x => x.User.Id == id && x.IsDeleted == false);
            return student;
        }
    }
}
