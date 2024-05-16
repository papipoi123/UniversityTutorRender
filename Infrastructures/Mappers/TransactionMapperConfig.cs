using Applications.Commons;
using Applications.ViewModels;
using AutoMapper;
using Domain.Base;
using Domain.Entities;

namespace Infrastructures.Mappers
{
    public class TransactionMapperConfig : Profile
    {
        public TransactionMapperConfig()
        {
            CreateMap<Transaction, TransactionViewModel>().ReverseMap();
        }
    }
}
