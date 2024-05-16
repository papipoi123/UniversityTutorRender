using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;
using System.Net;

namespace Applications.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> CreateStudent(StudentViewModel studentViewModel)
        {
            Wallet walletObj = new Wallet();
            walletObj.IsDeleted = false;
            walletObj.WalletAmount = 0;
            var studentObj = _mapper.Map<Student>(studentViewModel);
            studentObj.User.Wallet = walletObj;
            await _unitOfWork.StudentRepository.CreateAsync(studentObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync();
            if (isSuccess > 0)
            {
                return new Response(HttpStatusCode.OK, "Create success");
            }
            return new Response(HttpStatusCode.BadRequest, "Create fail");
        }

        public async Task<Response> GetAllStudent(int pageIndex = 0, int pageSize = 10)
        {
            var studentObj = await _unitOfWork.StudentRepository.GetAllStudent(pageIndex, pageSize);
            var result = _mapper.Map<Pagination<GetStudentViewModel>>(studentObj);
            if (studentObj.Items.Count() < 1)
            {
                return new Response(HttpStatusCode.NotFound, "No Student Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> GetStudentInfor(int id)
        {
            var studentObj = await _unitOfWork.StudentRepository.GetStudentInfo(id);
            var result = _mapper.Map<GetStudentViewModel>(studentObj);
            if (studentObj is null)
            {
                return new Response(HttpStatusCode.NotFound, "No Student Found");
            }
            return new Response(HttpStatusCode.OK, "Success", result);
        }

        public async Task<Response> RemoveStudent(int id)
        {
            var studentObj = await _unitOfWork.StudentRepository.GetStudentInfo(id);
            if (studentObj is not null)
            {
                _unitOfWork.UserRepository.DeleteAsync(studentObj.User);
                _unitOfWork.StudentRepository.DeleteAsync(studentObj);
                var isSuccess = await _unitOfWork.SaveChangeAsync();
                if (isSuccess > 0)
                {
                    return new Response(HttpStatusCode.OK, "Success");
                }
                return new Response(HttpStatusCode.BadRequest, "Fail");
            }
            return new Response(HttpStatusCode.NotFound, "Not found user id");
        }

        public async Task<Response> UpdateStudent(int id, UpdateStudentViewModel studentViewModel)
        {
            var studentObj = await _unitOfWork.StudentRepository.GetStudentInfo(id);
            if (studentObj is not null)
            {
                _mapper.Map(studentViewModel, studentObj);
                _unitOfWork.StudentRepository.UpdateAsync(studentObj);
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
