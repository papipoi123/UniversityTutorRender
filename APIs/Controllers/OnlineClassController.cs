using Applications.Commons;
using Applications.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OnlineClassController : ControllerBase
    {
        private readonly IOnlineClassService _service;

        public OnlineClassController(IOnlineClassService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<Response> Get(int pageIndex = 0, int pageSize = 10)
        {
            Response response = await _service.GetAllOnlineClass(pageIndex, pageSize);
            return response;
        }

        [HttpPost]
        public async Task<Response> Create(int studentId, int teachingCourseId)
        {
            return await _service.CreateOnlineClass(studentId, teachingCourseId);
        }

        [HttpDelete]
        public async Task<Response> Delete(int studentId, int teachingCourseId)
        {
            return await _service.DeleteOnlineClass(studentId, teachingCourseId);
        }
    }
}
