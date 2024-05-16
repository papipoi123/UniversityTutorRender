using Applications.Interfaces;
using Applications.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class FavoriteCourseRepository : GenericRepository<FavoriteCourse>, IFavoriteCourseRepository
    {
        public FavoriteCourseRepository(AppDbContext context, ICurrentTimeService currentTime, IClaimsServices claimsServices) : base(context, currentTime, claimsServices)
        {
        }

        public async Task<FavoriteCourse?> GetByStudentIdAndTeachingCourseId(int studentId, int teachingCourseId)
        {
            var favoriteCourse = await _dbSet.FirstOrDefaultAsync(x => x.StudentId == studentId && x.TeachingCourseId == teachingCourseId && x.IsDeleted == false);
            return favoriteCourse;
        }
    }
}
