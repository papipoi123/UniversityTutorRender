using Applications.Commons;
using Applications.ViewModels;
using Domain.Entities;

namespace Applications.Repositories
{
    public interface ITeachingCourseRepository : IGenericRepository<TeachingCourse>
    {
        Task<Pagination<TeachingCourse>> ToPaginationTCC(int pageIndex = 0, int pageSize = 10);

        Task<TeachingCourse> GetTCCByIdAsync(int id);
        Task<Pagination<TeachingCourse>> Filter(FilterTeachingCourseRequest request, int pageIndex = 0, int pageSize = 10);
        Task<List<TeachingCourse?>> GetListTeachingCourse(int id);
        Task<List<TeachingCourse?>> GetListTeachingCourse();
    }
}
