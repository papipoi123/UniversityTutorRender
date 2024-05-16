using Applications.Commons;
using Applications.ViewModels;
using AutoMapper;
using Domain.Base;
using Domain.Entities;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Infrastructures.Mappers
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            /* pagination */
            CreateMap(typeof(Pagination<>), typeof(Pagination<>));
    
            CreateMap<Admin, AdminViewModel>().ReverseMap();
            CreateMap<Admin, GetAdminViewModel>().ReverseMap();

            CreateMap<Tutor, TutorViewModel>().ReverseMap();
            CreateMap<Tutor, GetTutorViewModel>().ReverseMap();
            CreateMap<Tutor, TutorViewModelForRegis>().ReverseMap();
            CreateMap<Tutor, UpdateTutorViewModel>().ReverseMap();

            CreateMap<Student, StudentViewModel>().ReverseMap();
            CreateMap<Student, GetStudentViewModel>().ReverseMap();
            CreateMap<Student, UpdateStudentViewModel>().ReverseMap();

            CreateMap<Report, ReportViewModel>().ReverseMap();

            CreateMap<TutorFeedback, TutorFeedbackViewModel>().ReverseMap();
            CreateMap<TutorFeedback, GetTutorFeedbackViewModel>().ReverseMap();

            CreateMap<Certification, CertificationViewModel>().ReverseMap();
            CreateMap<Certification, GetCertificationViewModel>().ReverseMap();

            CreateMap<Unit, UnitViewModel>().ReverseMap();
            CreateMap<Unit, GetUnitViewModel>().ReverseMap();

            CreateMap<University, UniversityViewModel>().ReverseMap();
            CreateMap<University, GetUniversityViewModel>().ReverseMap();

            CreateMap<CourseMajor, CourseMajorViewModel>().ReverseMap();
            CreateMap<CourseMajor, GetCourseMajorViewModel>().ReverseMap();

            CreateMap<FavoriteCourse, GetFavoriteCourseViewModel>().ReverseMap();

            CreateMap<Rating, RatingViewModel>().ReverseMap();
            CreateMap<Rating, GetRatingViewModel>().ReverseMap(); 
            
            CreateMap<Role, RoleViewModel>().ReverseMap();
            CreateMap<Role, GetRoleViewModel>().ReverseMap();


        }
    }
}
