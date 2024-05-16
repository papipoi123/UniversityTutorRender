using Applications.Commons;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Infrastructures.Mappers
{
    public class TeachingCourseMapperConfig : Profile
    {
        public TeachingCourseMapperConfig()
        {
            CreateMap<TeachingCourse, TeachingCourseViewModel>().ReverseMap();
            CreateMap<TeachingCourse, GetTeachingCourseViewModel>().ReverseMap();
        }
    }
}
