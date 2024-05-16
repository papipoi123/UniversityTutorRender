using Applications.Interfaces;
using Applications.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        public RatingRepository(AppDbContext context, ICurrentTimeService currentTime, IClaimsServices claimsServices) : base(context, currentTime, claimsServices)
        {
        }

        public double getAvgrating(int id)
        {
            return _dbSet.Where(x => x.TeachingCourseId == id).Average(x => x.RatingStar);
        }

        public async Task<List<Rating?>> getByTeachingCourseId(int id)
        {
            var rating = await _dbSet.Where(x => x.TeachingCourseId == id).ToListAsync();
            return rating;
        }
    }
}
