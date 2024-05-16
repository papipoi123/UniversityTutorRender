using Applications.Commons;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Infrastructures.Mappers
{
    public class OnlineClassMapperConfig : Profile
    {
        public OnlineClassMapperConfig()
        {
            CreateMap<OnlineClass, GetOnlineClassViewModel>().ReverseMap();
        
        }
    }
}
