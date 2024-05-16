using Applications.Interfaces;
using Applications.Repositories;
using Domain.Entities;

namespace Infrastructures.Repositories
{
    public class WeeklyTimeRepository : GenericRepository<WeeklyTime>, IWeeklyTimeRepository
    {
        public WeeklyTimeRepository(AppDbContext context, ICurrentTimeService currentTime, IClaimsServices claimsServices) : base(context, currentTime, claimsServices)
        {
        }
    }
}
