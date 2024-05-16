using Domain.Entities;

namespace Applications.Repositories
{
    public interface IFavoriteCourseRepository : IGenericRepository<FavoriteCourse>
    {
        Task<FavoriteCourse?> GetByStudentIdAndTeachingCourseId(int studentId, int teachingCourseId);
    }
}
