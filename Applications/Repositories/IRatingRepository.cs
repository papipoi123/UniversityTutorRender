using Domain.Entities;

namespace Applications.Repositories
{
    public interface IRatingRepository : IGenericRepository<Rating>
    {
        double getAvgrating(int id);
        Task<List<Rating?>> getByTeachingCourseId(int id);
    }
}
