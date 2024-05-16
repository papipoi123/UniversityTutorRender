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
    public class UniversityController : ControllerBase
    {
        public readonly IUniversityService _universityService;
        private readonly IValidator<UniversityViewModel> _validator;

        public UniversityController(IUniversityService universityService, IValidator<UniversityViewModel> validator)
        {
            _universityService = universityService;
            _validator = validator;
        }

        // GET: api/University
        [HttpGet]
        public async Task<Response> Get(int pageIndex = 0, int pageSize = 10)
        {
            var result = await _universityService.GetAllUniversity(pageIndex, pageSize);
            return result;
        }
        // GET api/University/5
        [HttpGet]
        public async Task<Response> GetById(int id)
        {
            Response result = await _universityService.GetUniversityInfor(id);
            return result;
        }

        // POST api/University
        [HttpPost]
        public async Task<Response> Create(UniversityViewModel model)
        {
            var result = await _universityService.CreateUniversity(model);
            return result;
        }

        // PUT api/University/5
        [HttpPut]
        public async Task<Response> Update(int id, UniversityViewModel model)
        {
            var result = await _universityService.UpdateUniversity(id, model);
            return result;
        }

        // DELETE api/University/5
        [HttpDelete]
        public async Task<Response> Delete(int id)
        {
            return await _universityService.RemoveUniversity(id);
        }

    }
}
