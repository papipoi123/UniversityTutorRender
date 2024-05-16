using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IValidator<StudentViewModel> _validator;

        public StudentController(IStudentService studentService, IValidator<StudentViewModel> validator)
        {
            _studentService = studentService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<Response> Get(int pageIndex = 0, int pageSize = 10)
        {
            return await _studentService.GetAllStudent(pageIndex, pageSize);
        }

        [HttpGet]
        public async Task<Response> GetById(int id)
        {
            return await _studentService.GetStudentInfor(id);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(StudentViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var valid = _validator.Validate(model);
        //        if (valid.IsValid)
        //        {
        //            var result = _studentService.CreateStudent(model);
        //            if (result is not null)
        //            {
        //                return Ok("Success");
        //            }
        //            return BadRequest("Fail");
        //        }
        //    }
        //    return BadRequest("Create fail, invalid info");
        //}

        [HttpPut]
        public async Task<Response> Update(int id, UpdateStudentViewModel model)
        {
            return await _studentService.UpdateStudent(id, model);
        }

        [HttpDelete]
        public async Task<Response> Delete(int id)
        {
            return await _studentService.RemoveStudent(id);
        }
    }
}
