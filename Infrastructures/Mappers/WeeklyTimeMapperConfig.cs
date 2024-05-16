using Applications.Commons;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Infrastructures.Mappers
{
    public class WeeklyTimeMapperConfig : Profile
    {
        public WeeklyTimeMapperConfig()
        {
            CreateMap<WeeklyTime, WeeklyTimeViewModel>().ReverseMap();
            CreateMap<WeeklyTime, GetWeeklyTimeViewModel>().ReverseMap();
        }
    }
}
