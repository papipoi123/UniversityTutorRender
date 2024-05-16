using Applications.Interfaces;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Mappers
{
    public class UserMapperConfig : Profile
    {
        public UserMapperConfig()
        {
            CreateMap<UserViewModel, User>()
                .ForMember(dest => dest.JoinDate, src =>src.MapFrom(x=>DateTime.Now))
                .ReverseMap();
            CreateMap<User, LoginViewModel>().ReverseMap();
            CreateMap<RegisterViewModel, User>()
                .ForMember(dest => dest.JoinDate, src =>src.MapFrom(x=> DateTime.Now))
                .ReverseMap();
            CreateMap<GetUserViewModel, User>().ReverseMap();
            CreateMap<RegisTutorModel, User>().ReverseMap();
            CreateMap<UpdateUserViewModel, User>().ReverseMap();
        }
    }
}
