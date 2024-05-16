using Applications.Commons;
using Applications.ViewModels;
using AutoMapper.Configuration.Conventions;

namespace Applications.Interfaces
{
    public interface IReportService
    {
        Task<Response> GetReportInfor(int id);
        Task<Response> GetAllReport(int pageIndex = 0, int pageSize = 10);
        Task<Response> CreateReport(ReportViewModel reportViewModel);
        Task<Response> UpdateReport(int id, ReportViewModel reportViewModel);
        Task<Response> RemoveReport(int id);
    }
}
