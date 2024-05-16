using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<Response> Login(LoginViewModel model)
        {
            return await _userService.Login(model);
        }
        [HttpPost]
        public async Task<Response> Register(UserViewModel model)
        {
            return await _userService.CreateUser(model);
        }

        [HttpDelete]
        public async Task<Response> Ban(int id)
        {
            return await _userService.RemoveUser(id);
        }

        [HttpPut]
        public async Task<Response> Update(int id, UserViewModel model)
        {
            return await _userService.UpdateUser(id, model);
        }

        [HttpGet]
        public async Task<Response> Info(int id)
        {
            return await _userService.GetUserInfor(id);
        }

        [HttpGet]
        public async Task<Response> GetAllUser(int pageIndex = 0, int pageSize = 10)
        {
            return await _userService.GetAllUser(pageIndex, pageSize);
        }

        [HttpPost]
        public async Task<Response> ResetPassword(ResetPasswordRequest request)
        {
            return await _userService.ResetPassword(request);
        }

        [HttpPost]
        public async Task<Response> RegisterTutor(RegisTutorModel model)
        {
            return await _userService.RegisterTutor(model);
        }
    }
}
