using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly ITutorService _tutorService;
        private readonly IValidator<TutorViewModel> _validator;

        public TutorController(ITutorService tutorService, IValidator<TutorViewModel> validator)
        {
            _tutorService = tutorService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<Response> Get(int pageIndex = 0, int pageSize = 10)
        {
            return await _tutorService.GetAllTutor(pageIndex, pageSize);
        }

        [HttpGet]
        public async Task<Response> GetById(int id)
        {
            return await _tutorService.GetTutorInfor(id);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(TutorViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var valid = _validator.Validate(model);
        //        if (valid.IsValid)
        //        {
        //            var result = await _tutorService.CreateTutor(model);
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
        public async Task<Response> Update(int id, UpdateTutorViewModel model)
        {
            return await _tutorService.UpdateTutor(id, model);
        }

        [HttpDelete]
        public async Task<Response> Delete(int id)
        {
            return await _tutorService.RemoveTutor(id);
        }
    }
}
