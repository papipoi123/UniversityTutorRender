using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class CertificationService : ICertificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CertificationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> CreateCertification(CertificationViewModel certificationViewModel)
        {
            var tutorId = await _unitOfWork.TutorRepository.GetEntityByIdAsync(certificationViewModel.TutorId);
            if (tutorId is null)
            {
                return new Response(HttpStatusCode.NotFound, "Not found tutor id");
            }
            var certificationObj = _mapper.Map<Certification>(certificationViewModel);
            await _unitOfWork.CertificationRepository.CreateAsync(certificationObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                return new Response(HttpStatusCode.OK, "Create success");
            }
            return new Response(HttpStatusCode.BadRequest, "Create fail");
        }

        public async Task<Response> GetAllCertification(int pageIndex = 0, int pageSize = 10)
        {
            var certificationObj = await _unitOfWork.CertificationRepository.ToPagination(pageIndex, pageSize);
            var result = _mapper.Map<Pagination<GetCertificationViewModel>>(certificationObj);
            if (certificationObj.Items.Count() < 1)
            {
                return new Response(HttpStatusCode.NoContent, "No Certification Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> GetCertificationInfor(int id)
        {
            var certificationObj = await _unitOfWork.CertificationRepository.GetEntityByIdAsync(id);
            var result = _mapper.Map<GetCertificationViewModel>(certificationObj);
            if (certificationObj is null)
            {
                return new Response(HttpStatusCode.NoContent, "No Certification Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> RemoveCertification(int id)
        {
            var certificationObj = await _unitOfWork.CertificationRepository.GetEntityByIdAsync(id);
            if (certificationObj is not null)
            {
                _unitOfWork.CertificationRepository.DeleteAsync(certificationObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Fail");
        }

        public async Task<Response> UpdateCertification(int id, CertificationViewModel certificationViewModel)
        {
            var certificationObj = await _unitOfWork.CertificationRepository.GetEntityByIdAsync(id);
            if (certificationObj is not null)
            {
                var tutorId = await _unitOfWork.TutorRepository.GetEntityByIdAsync(certificationViewModel.TutorId);
                if (tutorId is null)
                {
                    return new Response(HttpStatusCode.NotFound, "Not found tutor id");
                }
                _mapper.Map(certificationViewModel, certificationObj);
                _unitOfWork.CertificationRepository.UpdateAsync(certificationObj);
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
