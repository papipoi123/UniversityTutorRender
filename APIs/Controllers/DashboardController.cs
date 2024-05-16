using Applications.Commons;
using Applications.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;

        public DashboardController(IDashboardService service)
        {
            _service = service;
        }

        [HttpGet]
        public Response GetTutor()
        {
            return _service.GetTutor();
        }

        [HttpGet]
        public Response GetStudent()
        {
            return _service.GetStudent();
        }

        [HttpGet]
        public Response GetTutorInMonth()
        {
            return _service.GetTutorInMonth();
        }

        [HttpGet]
        public Response GetStudentInMonth()
        {
            return _service.GetStudentInMonth();
        }

        [HttpGet]
        public Response GetCourseSelled()
        {
            return _service.GetCourseSelled();
        }

        [HttpGet]
        public Response GetOrderInMonth()
        {
            return _service.GetOrderInMonth();
        }

        [HttpGet]
        public Response GetCourseCreatedInMonth()
        {
            return _service.GetCourseCreatedInMonth();
        }
    }
}
