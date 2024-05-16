using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeachingCourseController : ControllerBase
    {
        public readonly ITeachingCourseService _teachingCourseService;

        public TeachingCourseController(ITeachingCourseService teachingCourseService)
        {
            _teachingCourseService = teachingCourseService;
        }

        // GET: api/TeachingCourse/
        [HttpGet]
        public async Task<Response> Get()
        {
            var list = await _teachingCourseService.GetAllTeachingCourse();
            return list;
        }

        // GET api/TeachingCourse/1/
        [HttpGet]
        public async Task<Response> GetById(int id)
        {
            var report = await _teachingCourseService.GetTeachingCourseInfor(id);
            return report;
        }

        // POST api/TeachingCourse/
        [HttpPost]
        public async Task<Response> Post([FromBody] TeachingCourseViewModel value)
        {
            return await _teachingCourseService.CreateTeachingCourse(value);
        }

        // PUT api/TeachingCourse/1
        [HttpPut]
        public async Task<Response> Put(int id, [FromBody] TeachingCourseViewModel value)
        {
            return await _teachingCourseService.UpdateTeachingCourse(id, value);
        }

        // DELETE api/TeachingCourse/1
        [HttpDelete]
        public async Task<Response> Delete(int id)
        {
            return await _teachingCourseService.RemoveTeachingCourse(id);
        }

        [HttpGet]
        public async Task<Response> Filter([FromQuery] FilterTeachingCourseRequest request, int pageIndex = 0, int pageSize = 10)
        {
            return await _teachingCourseService.FilterTeachingCourse(request, pageIndex, pageSize);
        }
    }
}
