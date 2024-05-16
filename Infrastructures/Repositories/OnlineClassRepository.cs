using Applications.Interfaces;
using Applications.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class OnlineClassRepository : GenericRepository<OnlineClass>, IOnlineClassRepository
    {
        public OnlineClassRepository(AppDbContext context, ICurrentTimeService currentTime, IClaimsServices claimsServices) : base(context, currentTime, claimsServices)
        {
        }

        public async Task<OnlineClass?> GetByStudentIdAndTeachingCourseId(int studentId, int teachingCourseId)
        {
            var onlineClass = await _dbSet.FirstOrDefaultAsync(x => x.StudentId == studentId && x.TeachingCourseId == teachingCourseId && x.IsDeleted == false);
            return onlineClass;
        }
    }
}
