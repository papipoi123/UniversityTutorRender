using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _service;

        public RatingController(IRatingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<Response> Get(int pageIndex = 0, int pageSize = 10)
        {
            return await _service.GetAllRating(pageIndex, pageSize);
        }

        [HttpGet]
        public async Task<Response> GetById(int id)
        {
            return await _service.GetRatingInfor(id);
        }

        [HttpPost]
        public async Task<Response> Create(RatingViewModel model)
        {
            return await _service.CreateRating(model);
        }

        [HttpPut]
        public async Task<Response> Update(int id, RatingViewModel model)
        {
            return await _service.UpdateRating(id, model);
        }

        [HttpDelete]
        public async Task<Response> Delete(int id)
        {
            return await _service.RemoveRating(id);
        }
    }
}
