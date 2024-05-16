using Applications.Commons;
using Applications.ViewModels;

namespace Applications.Interfaces
{
    public interface IWeeklyTimeService
    {
        Task<Response> CreateWeeklyTime(WeeklyTimeViewModel weeklyTimeViewModel);
        Task<Response> GetAllWeeklyTime(int pageIndex = 0, int pageSize = 10);
        Task<Response> GetWeeklyTimeInfor(int id);
        Task<Response> RemoveWeeklyTime(int id);
        Task<Response> UpdateWeeklyTime(int id, WeeklyTimeViewModel weeklyTimeViewModel);
    }
}