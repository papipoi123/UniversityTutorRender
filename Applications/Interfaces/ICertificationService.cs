using Applications.Commons;
using Applications.ViewModels;

namespace Applications.Interfaces
{
    public interface ICertificationService
    {
        Task<Response> GetCertificationInfor(int id);
        Task<Response> GetAllCertification(int pageIndex = 0, int pageSize = 10);
        Task<Response> CreateCertification(CertificationViewModel certificationViewModel);
        Task<Response> UpdateCertification(int id, CertificationViewModel certificationViewModel);
        Task<Response> RemoveCertification(int id);
    }
}
