using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class TutorService : ITutorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TutorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> CreateTutor(TutorViewModel tutorViewModel)
        {
            Wallet walletObj = new Wallet();
            walletObj.IsDeleted = false;
            walletObj.WalletAmount = 0;
            var tutorObj = _mapper.Map<Tutor>(tutorViewModel);
            tutorObj.User.Wallet = walletObj;
            await _unitOfWork.TutorRepository.CreateAsync(tutorObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                return new Response(HttpStatusCode.OK, "Create success");
            }
            return new Response(HttpStatusCode.BadRequest, "Create fail");
        }

        public async Task<Response> GetAllTutor(int pageIndex = 0, int pageSize = 10)
        {
            var tutorObj = await _unitOfWork.TutorRepository.GetAllTutor(pageIndex, pageSize);
            var result = _mapper.Map<Pagination<GetTutorViewModel>>(tutorObj);
            if (tutorObj.Items.Count() < 1)
            {
                return new Response(HttpStatusCode.NotFound, "No Tutor Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> GetTutorInfor(int id)
        {
            var tutorObj = await _unitOfWork.TutorRepository.GetTutorInfo(id);
            var result = _mapper.Map<GetTutorViewModel>(tutorObj);
            if (tutorObj is null)
            {
                return new Response(HttpStatusCode.NotFound, "No Tutor Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> RemoveTutor(int id)
        {
            var tutorObj = await _unitOfWork.TutorRepository.GetTutorInfo(id);
            if (tutorObj is not null)
            {
                _unitOfWork.UserRepository.DeleteAsync(tutorObj.User);
                _unitOfWork.TutorRepository.DeleteAsync(tutorObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
                return new Response(HttpStatusCode.BadRequest, "Fail");
            }
            return new Response(HttpStatusCode.NotFound, "Not found user id");
        }

        public async Task<Response> UpdateTutor(int id, UpdateTutorViewModel tutorViewModel)
        {
            var tutorObj = await _unitOfWork.TutorRepository.GetTutorInfo(id);
            if (tutorObj is not null)
            {
                _mapper.Map(tutorViewModel, tutorObj);
                _unitOfWork.TutorRepository.UpdateAsync(tutorObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
                return new Response(HttpStatusCode.BadRequest, "Fail");
            }
            return new Response(HttpStatusCode.NotFound, "Not found user id");
        }
    }
}
