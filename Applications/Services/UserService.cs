using Applications.Commons;
using Applications.Interfaces;
using Applications.Utils;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JWTSection _jwtSection;
        private readonly IMapper _mapper;
        private readonly IClaimsServices _claimsServices;
        public UserService(IUnitOfWork unitOfWork,
            JWTSection jwtSection,
            IMapper mapper,
            IClaimsServices claimsServices)
        {
            _unitOfWork = unitOfWork;
            _jwtSection = jwtSection;
            _mapper = mapper;
            _claimsServices = claimsServices;

        }

        public async Task<Response> CreateUser(UserViewModel userViewModel)
        {
            var isExist = await _unitOfWork.UserRepository.ExistEmail(userViewModel.Email);
            if (!isExist)
            {
                Wallet walletObj = new Wallet();
                walletObj.IsDeleted = false;
                walletObj.WalletAmount = 0;
                var user = _mapper.Map<User>(userViewModel);
                user.Wallet = walletObj;
                user.RoleId = 3;
                user.AccountStatus = Domain.Enums.AccountStatus.Normal;
                user.CreatedAt = DateTime.Now;
                user.Student.CreatedAt = DateTime.Now;
                await _unitOfWork.UserRepository.CreateAsync(user);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Create success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Create fail");
        }
        public async Task<Response> Register(RegisterViewModel userViewModel)
        {
            var isExist = await _unitOfWork.UserRepository.ExistEmail(userViewModel.Email);
            if (!isExist)
            {
                var user = _mapper.Map<User>(userViewModel);
                await _unitOfWork.UserRepository.CreateAsync(user);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Register success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Register fail");
        }

        public async Task<Response> GetAllUser(int pageIndex = 0, int pageSize = 10)
        {
            var productObj = await _unitOfWork.UserRepository.ToPagination(pageIndex, pageSize);
            var result = _mapper.Map<Pagination<GetUserViewModel>>(productObj);
            if (productObj.Items.Count() < 1)
            {
                return new Response(HttpStatusCode.NoContent, "No User Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> GetUserInfor(int id)
        {
            var productObj = await _unitOfWork.UserRepository.GetEntityByIdAsync(id);
            var result = _mapper.Map<GetUserViewModel>(productObj);
            if (productObj is null)
            {
                return new Response(HttpStatusCode.NoContent, "No User Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> Login(LoginViewModel loginViewModel)
        {
            var user = await _unitOfWork.UserRepository.Login(loginViewModel.Email, loginViewModel.Password);
            if (user == null)
            {
                return new Response(HttpStatusCode.BadRequest, "Invalid email or password");
            }
            return new Response(HttpStatusCode.OK, "Success", StringUtils.GenerateJwtToken(user, _jwtSection));
        }

        public async Task<Response> RemoveUser(int id)
        {
            var userObj = await _unitOfWork.UserRepository.GetEntityByIdAsync(id);
            if (userObj is not null)
            {
                _unitOfWork.UserRepository.DeleteAsync(userObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Fail");
        }

        public async Task<Response> ResetPassword(ResetPasswordRequest request)
        {
            var user = await _unitOfWork.UserRepository.GetUserByCode(request.Code);

            if (user is null || user.ResetCodeExpires < DateTime.Now)
            {
                return new Response(HttpStatusCode.BadRequest, "Invalid code!");
            }

            if (string.CompareOrdinal(request.Password, request.ConfirmPassword) != 0)
            {
                return new Response(HttpStatusCode.BadRequest, "the password and confirm password does not match!");
            }
            user.Password = request.ConfirmPassword;
            user.CodeResetPassword = null;
            user.ResetCodeExpires = null;
            _unitOfWork.UserRepository.UpdateAsync(user);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                return new Response(HttpStatusCode.OK, "Success");
            }
            return new Response(HttpStatusCode.BadRequest, "Fail");
        }

        public async Task<Response> UpdateUser(int id, UserViewModel userViewModel)
        {
            var userObj = await _unitOfWork.UserRepository.GetEntityByIdAsync(id);
            if (userObj is not null)
            {
                _mapper.Map(userViewModel, userObj);
                _unitOfWork.UserRepository.UpdateAsync(userObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Fail");
        }

        public async Task<Response> RegisterTutor(RegisTutorModel model)
        {
            var isExist = await _unitOfWork.UserRepository.ExistEmail(model.Email);
            if (!isExist)
            {
                Wallet walletObj = new Wallet();
                walletObj.IsDeleted = false;
                walletObj.WalletAmount = 0;
                var user = _mapper.Map<User>(model);
                user.Wallet = walletObj;
                user.RoleId = 2;
                user.AccountStatus = Domain.Enums.AccountStatus.Normal;
                user.CreatedAt = DateTime.Now;
                user.Tutor.CreatedAt = DateTime.Now;
                user.Tutor.TutorAuthorize = Domain.Enums.TutorAuthorize.Waiting;
                await _unitOfWork.UserRepository.CreateAsync(user);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Create success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Create fail");
        }
    }
}
