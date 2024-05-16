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
    public class ReportController : ControllerBase
    {
        public readonly IReportService _reportService;
        private readonly IValidator<ReportViewModel> _validator;

        public ReportController(IReportService reportService, IValidator<ReportViewModel> validator)
        {
            _reportService = reportService;
            _validator = validator;
        }

        // GET: api/Report
        [HttpGet]
        public async Task<Response> Get(int pageIndex = 0, int pageSize = 10)
        {
            var result = await _reportService.GetAllReport(pageIndex, pageSize);
            return result;
        }
        // GET api/Report/5
        [HttpGet]
        public async Task<Response> GetById(int id)
        {
            Response result = await _reportService.GetReportInfor(id);
            return result;
        }

        // POST api/Report
        [HttpPost]
        public async Task<Response> Create(ReportViewModel model)
        {
            var result = await _reportService.CreateReport(model);
            return result;
        }

        // PUT api/Report/5
        [HttpPut]
        public async Task<Response> Update(int id, ReportViewModel model)
        {
            var result = await _reportService.UpdateReport(id, model);
            return result;
        }

        // DELETE api/Report/5
        [HttpDelete]
        public async Task<Response> Delete(int id)
        {
            return await _reportService.RemoveReport(id);
        }
    }
}
