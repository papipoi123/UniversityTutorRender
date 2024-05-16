using Applications.Commons;
using Applications.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Infrastructures.Mappers
{
    public class ReportMapperConfig : Profile
    {
        public ReportMapperConfig()
        {
            CreateMap<Report, ReportViewModel>().ReverseMap();
       
        }
    }
}
