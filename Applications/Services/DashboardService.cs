using Applications.Commons;
using Applications.Interfaces;
using System.Net;

namespace Applications.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Response GetCourseCreatedInMonth()
        {
            var result = _unitOfWork.DashboardRepository.GetCourseCreatedInMonth();
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public Response GetCourseSelled()
        {
            var result = _unitOfWork.DashboardRepository.GetCourseSelled();
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public Response GetOrderInMonth()
        {
            var result = _unitOfWork.DashboardRepository.GetOrderInMonth();
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public Response GetStudent()
        {
            var result = _unitOfWork.DashboardRepository.GetStudent();
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public Response GetStudentInMonth()
        {
            var result = _unitOfWork.DashboardRepository.GetStudentInMonth();
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public Response GetTutor()
        {
            var result = _unitOfWork.DashboardRepository.GetTutor();
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public Response GetTutorInMonth()
        {
            var result = _unitOfWork.DashboardRepository.GetTutorInMonth();
            return new Response(HttpStatusCode.OK, "Success", result);
        }
    }
}
