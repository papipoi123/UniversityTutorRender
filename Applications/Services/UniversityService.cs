using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsServices _claimsServices;
        public UniversityService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IClaimsServices claimsServices)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsServices = claimsServices;
        }

        public async Task<Response> GetAllUniversity(int pageIndex = 0, int pageSize = 10)
        {
            var universityObj = await _unitOfWork.UniversityRepository.ToPagination(pageIndex, pageSize);
            var result = _mapper.Map<Pagination<GetUniversityViewModel>>(universityObj);
            if (!universityObj.Items.Any())
            {
                return new Response(HttpStatusCode.NotFound, "No University Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> GetUniversityInfor(int id)
        {
            var universityObj = await _unitOfWork.UniversityRepository.GetEntityByIdAsync(id);
            var result = _mapper.Map<GetUniversityViewModel>(universityObj);
            if (universityObj is null)
            {
                return new Response(HttpStatusCode.NotFound, "No University Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> RemoveUniversity(int id)
        {
            var universityObj = await _unitOfWork.UniversityRepository.GetEntityByIdAsync(id);
            if (universityObj is not null)
            {

                _unitOfWork.UniversityRepository.DeleteAsync(universityObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Fail");
        }

        public async Task<Response> UpdateUniversity(int id, UniversityViewModel universityViewModel)
        {
            var universityObj = await _unitOfWork.UniversityRepository.GetEntityByIdAsync(id);
            if (universityObj is null)
                return new Response(HttpStatusCode.BadRequest, "Fail");

            _mapper.Map(universityViewModel, universityObj);
            _unitOfWork.UniversityRepository.UpdateAsync(universityObj);
            await _unitOfWork.SaveChangeAsync();

            return new Response(HttpStatusCode.Accepted, "Success");
        }
        public async Task<Response> CreateUniversity(UniversityViewModel universityViewModel)
        {
            var universityObj = _mapper.Map<University>(universityViewModel);
            await _unitOfWork.UniversityRepository.CreateAsync(universityObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                return new Response(HttpStatusCode.Created, "Create success");
            }
            return new Response(HttpStatusCode.BadRequest, "Create fail");
        }
    }
}
