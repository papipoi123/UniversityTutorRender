using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> CreateAdmin(AdminViewModel model)
        {
            var adminObj = _mapper.Map<Admin>(model);
            await _unitOfWork.AdminRepository.CreateAsync(adminObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                return new Response(HttpStatusCode.OK, "Create success");
            }
            return new Response(HttpStatusCode.BadRequest, "Create fail");
        }

        public async Task<Response> GetAdminInfor(int id)
        {
            var adminObj = await _unitOfWork.AdminRepository.GetAdminById(id);
            var result = _mapper.Map<GetAdminViewModel>(adminObj);
            if (adminObj is null)
            {
                return new Response(HttpStatusCode.NoContent, "No Admin Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> GetAllAdmin(int pageIndex = 0, int pageSize = 10)
        {
            var adminObj = await _unitOfWork.AdminRepository.GetAllAdmin(pageIndex, pageSize);
            var result = _mapper.Map<Pagination<GetAdminViewModel>>(adminObj);
            if (adminObj.Items.Count() < 1)
            {
                return new Response(HttpStatusCode.NoContent, "No Admin Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> RemoveAdmin(int id)
        {
            var adminObj = await _unitOfWork.AdminRepository.GetAdminById(id);
            if (adminObj is not null)
            {
                _unitOfWork.UserRepository.DeleteAsync(adminObj.User);
                _unitOfWork.AdminRepository.DeleteAsync(adminObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Fail");
        }

        public async Task<Response> UpdateAdmin(int id, AdminViewModel model)
        {
            var adminObj = await _unitOfWork.AdminRepository.GetAdminById(id);
            if (adminObj is not null)
            {
                _mapper.Map(model, adminObj);
                _unitOfWork.AdminRepository.UpdateAsync(adminObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Fail");
        }
    }
}
