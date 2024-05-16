using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CertificationController : ControllerBase
    {
        private readonly ICertificationService _certificationService;

        public CertificationController(ICertificationService certificationService)
        {
            _certificationService = certificationService;
        }

        [HttpGet]
        public async Task<Response> Get(int pageIndex = 0, int pageSize = 10)
        {
            return await _certificationService.GetAllCertification(pageIndex, pageSize);
        }

        [HttpGet]
        public async Task<Response> GetById(int id)
        {
            return await _certificationService.GetCertificationInfor(id);
        }

        [HttpPost]
        public async Task<Response> Create(CertificationViewModel model)
        {
            return await _certificationService.CreateCertification(model);
        }

        [HttpPut]
        public async Task<Response> Update(int id, CertificationViewModel model)
        {
            return await _certificationService.UpdateCertification(id, model);
        }

        [HttpDelete]
        public async Task<Response> Delete(int id)
        {
            return await _certificationService.RemoveCertification(id);
        }
    }
}
