using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class OnlineClassService : IOnlineClassService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OnlineClassService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> CreateOnlineClass(int studentId, int teachingCourseId)
        {
            var onlineClassObj = await _unitOfWork.OnlineClassRepository.GetByStudentIdAndTeachingCourseId(studentId, teachingCourseId);
            if (onlineClassObj is not null)
            {
                return new Response(HttpStatusCode.BadRequest, "Online Class existed!");
            }
            var studentObj = await _unitOfWork.StudentRepository.GetEntityByIdAsync(studentId);
            var teachingCourseObj = await _unitOfWork.TeachingCourseRepository.GetEntityByIdAsync(teachingCourseId);
            if (studentObj is not null && teachingCourseObj is not null)
            {
                var onlineClass = new OnlineClass
                {
                    Student = studentObj,
                    TeachingCourse = teachingCourseObj
                };
                await _unitOfWork.OnlineClassRepository.CreateAsync(onlineClass);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Create success");
                }
                return new Response(HttpStatusCode.BadRequest, "Create fail");
            }
            return new Response(HttpStatusCode.NotFound, "Student Id or Teaching Course Id not found!");
        }

        public async Task<Response> DeleteOnlineClass(int studentId, int teachingCourseId)
        {
            var onlineClassObj = await _unitOfWork.OnlineClassRepository.GetByStudentIdAndTeachingCourseId(studentId, teachingCourseId);
            if (onlineClassObj is not null)
            {
                _unitOfWork.OnlineClassRepository.DeleteAsync(onlineClassObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
            }
            return new Response(HttpStatusCode.BadRequest, "Fail");
        }

        public async Task<Response> GetAllOnlineClass(int pageIndex = 0, int pageSize = 10)
        {
            var onlineClassObj = await _unitOfWork.OnlineClassRepository.ToPagination(pageIndex, pageSize);
            var result = _mapper.Map<Pagination<GetOnlineClassViewModel>>(onlineClassObj);
            if (onlineClassObj.Items.Count() < 1)
            {
                return new Response(HttpStatusCode.NoContent, "No Online Class Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }
    }
}
