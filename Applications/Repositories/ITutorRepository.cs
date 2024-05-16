using Applications.Commons;
using Domain.Entities;

namespace Applications.Repositories
{
    public interface ITutorRepository : IGenericRepository<Tutor>
    {
        Task<Tutor?> GetTutorInfo(int id);
        Task<Pagination<Tutor?>> GetAllTutor(int pageIndex = 0, int pageSize = 10);
    }
}
