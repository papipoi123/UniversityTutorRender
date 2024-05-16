using Applications.Commons;
using Applications.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FavoriteCourseController : ControllerBase
    {
        private readonly IFavoriteCourseService _service;

        public FavoriteCourseController(IFavoriteCourseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<Response> Get(int pageIndex = 0, int pageSize = 10)
        {
            return await _service.GetAllFavoriteCourse(pageIndex, pageSize);
        }

        [HttpPost]
        public async Task<Response> Create(int studentId, int teachingCourseId)
        {
            return await _service.CreateFavoriteCourse(studentId, teachingCourseId);
        }

        [HttpDelete]
        public async Task<Response> Delete(int studentId, int teachingCourseId)
        {
            return await _service.DeleteFavoriteCourse(studentId, teachingCourseId);
        }
    }
}
