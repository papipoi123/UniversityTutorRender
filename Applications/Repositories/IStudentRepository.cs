using Applications.Commons;
using Domain.Entities;

namespace Applications.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<Student?> GetStudentInfo(int id);
        Task<Pagination<Student?>> GetAllStudent(int pageIndex = 0, int pageSize = 10);
    }
}
