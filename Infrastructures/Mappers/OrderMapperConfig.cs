using Applications.Commons;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Infrastructures.Mappers
{
    public class OrderMapperConfig : Profile
    {
        public OrderMapperConfig()
        {
            CreateMap<Order, OrderViewModel>().ReverseMap();
            
        }
    }
}
