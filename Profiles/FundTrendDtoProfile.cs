using AutoMapper;
using WebApplicationtest1.Models;
using WebApplicationtest1.ViewModels;

namespace WebApplicationtest1.Profiles
{
    public class FundTrendDtoProfile: Profile
    {
        public FundTrendDtoProfile()
        {
            CreateMap<Fund, FundTrendDto>();
            CreateMap<FundTrend, FundTrendDto>();
        }
    }
}
