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
    public class WeeklyTimeController : ControllerBase
    {
        public readonly IWeeklyTimeService _weeklyTimeService;
        private readonly IValidator<WeeklyTimeViewModel> _validator;

        public WeeklyTimeController(IWeeklyTimeService weeklyTimeService, IValidator<WeeklyTimeViewModel> validator)
        {
            _weeklyTimeService = weeklyTimeService;
            _validator = validator;
        }

        // GET: api/WeeklyTime
        [HttpGet]
        public async Task<Response> Get(int pageIndex = 0, int pageSize = 10)
        {
            var result = await _weeklyTimeService.GetAllWeeklyTime(pageIndex, pageSize);
            return result;
        }
        // GET api/WeeklyTime/5
        [HttpGet]
        public async Task<Response> GetById(int id)
        {
            Response result = await _weeklyTimeService.GetWeeklyTimeInfor(id);
            return result;
        }

        // POST api/WeeklyTime
        [HttpPost]
        public async Task<Response> Create(WeeklyTimeViewModel model)
        {
            var result = await _weeklyTimeService.CreateWeeklyTime(model);
            return result;
        }

        // PUT api/WeeklyTime/5
        [HttpPut]
        public async Task<Response> Update(int id, WeeklyTimeViewModel model)
        {
            var result = await _weeklyTimeService.UpdateWeeklyTime(id, model);
            return result;
        }

        // DELETE api/WeeklyTime/5
        [HttpDelete]
        public async Task<Response> Delete(int id)
        {
            return await _weeklyTimeService.RemoveWeeklyTime(id);
        }
    }
}
