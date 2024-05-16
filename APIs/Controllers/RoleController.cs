using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<Response> Get(int pageIndex = 0, int pageSize = 10)
        {
            return await _service.GetAllRole(pageIndex, pageSize);
        }

        [HttpGet]
        public async Task<Response> GetById(int id)
        {
            return await _service.GetRoleInfor(id);
        }

        [HttpPost]
        public async Task<Response> Create(RoleViewModel model)
        {
            return await _service.CreateRole(model);
        }

        [HttpPut]
        public async Task<Response> Update(int id, RoleViewModel model)
        {
            return await _service.UpdateRole(id, model);
        }

        [HttpDelete]
        public async Task<Response> Delete(int id)
        {
            return await _service.RemoveRole(id);
        }
    }
}
