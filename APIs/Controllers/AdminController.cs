using Applications.Commons;
using Applications.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<Response> Get(int pageIndex = 0, int pageSize = 10)
        {
            return await _service.GetAllAdmin(pageIndex, pageSize);
        }

        [HttpGet]
        public async Task<Response> GetById(int id)
        {
            return await _service.GetAdminInfor(id);
        }

        //[HttpPost]
        //public async Task<Response> Create(AdminViewModel model)
        //{
        //    return await _service.CreateAdmin(model);
        //}

        //[HttpPut]
        //public async Task<Response> Update(int id, AdminViewModel model)
        //{
        //    return await _service.UpdateAdmin(id, model);
        //}

        [HttpDelete]
        public async Task<Response> Delete(int id)
        {
            return await _service.RemoveAdmin(id);
        }
    }
}
