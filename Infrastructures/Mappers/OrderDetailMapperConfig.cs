using Applications.Commons;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Infrastructures.Mappers
{
    public class OrderDetailMapperConfig : Profile
    {
        public OrderDetailMapperConfig()
        {
            CreateMap<OrderDetail, OrderDetailViewModel>().ReverseMap();
    
        }
    }
}
