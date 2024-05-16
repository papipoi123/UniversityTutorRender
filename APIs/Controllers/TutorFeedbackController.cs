using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TutorFeedbackController : ControllerBase
    {
        private readonly ITutorFeedbackService _tutorFeedbackService;

        public TutorFeedbackController(ITutorFeedbackService tutorFeedbackService)
        {
            _tutorFeedbackService = tutorFeedbackService;
        }

        [HttpGet]
        public async Task<Response> Get(int pageIndex = 0, int pageSize = 10)
        {
            return await _tutorFeedbackService.GetAllTutorFeedback(pageIndex, pageSize);
        }

        [HttpGet]
        public async Task<Response> GetById(int id)
        {
            return await _tutorFeedbackService.GetTutorFeedbackInfor(id);
        }

        [HttpPost]
        public async Task<Response> Create(TutorFeedbackViewModel model)
        {
            return await _tutorFeedbackService.CreateTutorFeedback(model);
        }

        [HttpPut]
        public async Task<Response> Update(int id, TutorFeedbackViewModel model)
        {
            return await _tutorFeedbackService.UpdateTutorFeedback(id, model);
        }

        [HttpDelete]
        public async Task<Response> Delete(int id)
        {
            return await _tutorFeedbackService.RemoveTutorFeedback(id);
        }
    }
}
