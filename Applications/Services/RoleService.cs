using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> CreateRole(RoleViewModel model)
        {
            var roleObj = _mapper.Map<Role>(model);
            await _unitOfWork.RoleRepository.CreateAsync(roleObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                return new Response(HttpStatusCode.OK, "Create success");
            }
            return new Response(HttpStatusCode.BadRequest, "Create fail");
        }

        public async Task<Response> GetAllRole(int pageIndex = 0, int pageSize = 10)
        {
            var roleObj = await _unitOfWork.RoleRepository.ToPagination(pageIndex, pageSize);
            var result = _mapper.Map<Pagination<GetRoleViewModel>>(roleObj);
            if (roleObj.Items.Count() < 1)
            {
                return new Response(HttpStatusCode.NoContent, "No Role Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> GetRoleInfor(int id)
        {
            var customerObj = await _unitOfWork.RoleRepository.GetRoleInfo(id);
            var result = _mapper.Map<GetRoleViewModel>(customerObj);
            if (customerObj is null)
            {
                return new Response(HttpStatusCode.NoContent, "No Role Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> RemoveRole(int id)
        {
            var roleObj = await _unitOfWork.RoleRepository.GetEntityByIdAsync(id);
            if (roleObj is not null)
            {
                _unitOfWork.RoleRepository.DeleteAsync(roleObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Fail");
        }

        public async Task<Response> UpdateRole(int id, RoleViewModel model)
        {
            var roleObj = await _unitOfWork.RoleRepository.GetEntityByIdAsync(id);
            if (roleObj is not null)
            {
                _mapper.Map(model, roleObj);
                _unitOfWork.RoleRepository.UpdateAsync(roleObj);
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
