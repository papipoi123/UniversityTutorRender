using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class TutorFeedbackService : ITutorFeedbackService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TutorFeedbackService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> CreateTutorFeedback(TutorFeedbackViewModel tutorFeedbackViewModel)
        {
            var studentId = await _unitOfWork.StudentRepository.GetEntityByIdAsync(tutorFeedbackViewModel.StudentId);
            if (studentId is null)
            {
                return new Response(HttpStatusCode.NotFound, "Not found student id");
            }

            var tutorId = await _unitOfWork.TutorRepository.GetEntityByIdAsync(tutorFeedbackViewModel.TutorId);
            if (tutorId is null)
            {
                return new Response(HttpStatusCode.NotFound, "Not found tutor id");
            }

            var tutorFeedbackObj = _mapper.Map<TutorFeedback>(tutorFeedbackViewModel);
            await _unitOfWork.TutorFeedbackRepository.CreateAsync(tutorFeedbackObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                return new Response(HttpStatusCode.OK, "Create success");
            }
            return new Response(HttpStatusCode.BadRequest, "Create fail");
        }

        public async Task<Response> GetAllTutorFeedback(int pageIndex = 0, int pageSize = 10)
        {
            var tutorFeedbackObj = await _unitOfWork.TutorFeedbackRepository.ToPagination(pageIndex, pageSize);
            var result = _mapper.Map<Pagination<GetTutorFeedbackViewModel>>(tutorFeedbackObj);
            if (tutorFeedbackObj.Items.Count() < 1)
            {
                return new Response(HttpStatusCode.NoContent, "No Tutor Feedback Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> GetTutorFeedbackInfor(int id)
        {
            var tutorFeedbackObj = await _unitOfWork.TutorFeedbackRepository.GetEntityByIdAsync(id);
            var result = _mapper.Map<GetTutorFeedbackViewModel>(tutorFeedbackObj);
            if (tutorFeedbackObj is null)
            {
                return new Response(HttpStatusCode.NoContent, "No Tutor Feedback Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> RemoveTutorFeedback(int id)
        {
            var tutorFeedbackObj = await _unitOfWork.TutorFeedbackRepository.GetEntityByIdAsync(id);
            if (tutorFeedbackObj is not null)
            {
                _unitOfWork.TutorFeedbackRepository.DeleteAsync(tutorFeedbackObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Fail");
        }

        public async Task<Response> UpdateTutorFeedback(int id, TutorFeedbackViewModel tutorFeedbackViewModel)
        {
            var tutorFeedbackObj = await _unitOfWork.TutorFeedbackRepository.GetEntityByIdAsync(id);
            if (tutorFeedbackObj is not null)
            {
                var studentId = await _unitOfWork.StudentRepository.GetEntityByIdAsync(tutorFeedbackViewModel.StudentId);
                if (studentId is null)
                {
                    return new Response(HttpStatusCode.NotFound, "Not found student id");
                }

                var tutorId = await _unitOfWork.TutorRepository.GetEntityByIdAsync(tutorFeedbackViewModel.TutorId);
                if (tutorId is null)
                {
                    return new Response(HttpStatusCode.NotFound, "Not found tutor id");
                }
                _mapper.Map(tutorFeedbackViewModel, tutorFeedbackObj);
                _unitOfWork.TutorFeedbackRepository.UpdateAsync(tutorFeedbackObj);
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
