using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseMajorController : ControllerBase
    {
        public readonly ICourseMajorService _courseMajorService;
        private readonly IValidator<CourseMajorViewModel> _validator;

        public CourseMajorController(ICourseMajorService courseMajorService, IValidator<CourseMajorViewModel> validator)
        {
            _courseMajorService = courseMajorService;
            _validator = validator;
        }

        // GET: api/CourseMajor
        [HttpGet]
        public async Task<Response> Get(int pageIndex = 0, int pageSize = 10)
        {
            var result = await _courseMajorService.GetAllCourseMajor(pageIndex, pageSize);
            return result;
        }
        // GET api/CourseMajor/5
        [HttpGet]
        public async Task<Response> GetById(int id)
        {
            Response result = await _courseMajorService.GetCourseMajorInfor(id);
            return result;
        }

        // POST api/CourseMajor
        [HttpPost]
        public async Task<Response> Create(CourseMajorViewModel model)
        {
            var result = await _courseMajorService.CreateCourseMajor(model);
            return result;
        }

        // PUT api/CourseMajor/5
        [HttpPut]
        public async Task<Response> Update(int id, CourseMajorViewModel model)
        {
            var result = await _courseMajorService.UpdateCourseMajor(id, model);
            return result;
        }

        // DELETE api/CourseMajor/5
        [HttpDelete]
        public async Task<Response> Delete(int id)
        {
            return await _courseMajorService.RemoveCourseMajor(id);
        }
    }
}
