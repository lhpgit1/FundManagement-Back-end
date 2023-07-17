using AutoMapper;
using WebApplicationtest1.Models;
using WebApplicationtest1.ViewModels;

namespace WebApplicationtest1.Profiles
{
    public class TransRecordDtoProfile:Profile
    {
        public TransRecordDtoProfile()
        {
            CreateMap<Fund, TransRecordDto>();
            // .ForMember(dest => dest.FundName, opt => opt.MapFrom(src => src.FundName));
            CreateMap<Stock, TransRecordDto>();
                //.ForMember(dest => dest.StockName, opt => opt.MapFrom(src => src.StockName))
            CreateMap<TranscationRecord, TransRecordDto>();
        }
    }
}
