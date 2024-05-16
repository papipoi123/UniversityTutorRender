using Domain.Entities;

namespace Applications.Repositories
{
    public interface IOnlineClassRepository : IGenericRepository<OnlineClass>
    {
        Task<OnlineClass?> GetByStudentIdAndTeachingCourseId(int studentId, int teachingCourseId);
    }
}
