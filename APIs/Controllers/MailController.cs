using Applications.Commons;
using Applications.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _service;

        public MailController(IMailService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<Response> SendEmailForgotPassword(string email)
        {
            return await _service.SendAsync(email);
        }
    }
}
