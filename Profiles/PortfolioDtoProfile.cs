using AutoMapper;
using WebApplicationtest1.Models;
using WebApplicationtest1.ViewModels;

namespace WebApplicationtest1.Profiles
{
    public class PortfolioDtoProfile : Profile
    {
        public PortfolioDtoProfile()
        {
            CreateMap<Fund, PortfolioDto>();
            //.ForMember(dest => dest.FundName, opt => opt.MapFrom(src => src.FundName));
            CreateMap<Stock, PortfolioDto>();
            // .ForMember(dest => dest.StockName, opt => opt.MapFrom(src => src.StockName))
            // .ForMember(dest => dest.StockType, opt => opt.MapFrom(src => src.StockType));
            CreateMap<StockTrend, PortfolioDto>();
                //.ForMember(dest => dest.StockDailyCloseprice, opt => opt.MapFrom(src => src.StockDailyCloseprice));
            CreateMap<InvestmentPortfolio, PortfolioDto>();
        }
    }
}
