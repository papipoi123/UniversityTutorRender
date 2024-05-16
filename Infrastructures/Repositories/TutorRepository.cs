using Applications.Commons;
using Applications.Interfaces;
using Applications.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class TutorRepository : GenericRepository<Tutor>, ITutorRepository
    {
        public TutorRepository(AppDbContext context, ICurrentTimeService currentTime, IClaimsServices claimsServices) : base(context, currentTime, claimsServices)
        {
        }

        public async Task<Pagination<Tutor?>> GetAllTutor(int pageIndex = 0, int pageSize = 10)
        {
            var itemCount = await _dbSet.Where(x => x.IsDeleted == false).CountAsync();
            var items = await _dbSet.Include(x => x.User)
                                    .Where(x => x.IsDeleted == false)
                                    .Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .AsNoTracking()
                                    .ToListAsync();

            var result = new Pagination<Tutor>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItemsCount = itemCount,
                Items = items,
            };
            return result;
        }

        public async Task<Tutor?> GetTutorInfo(int id)
        {
            var tutor = await _dbSet.Include(x => x.User)
                                    .Include(x => x.Certifications)
                                    .Include(x => x.TutorFeedbacks)
                                    .Include(x => x.TeachingCourses)
                                    .FirstOrDefaultAsync(x => x.User.Id == id && x.IsDeleted == false);
            return tutor;
        }
    }
}
