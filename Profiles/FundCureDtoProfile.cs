using AutoMapper;
using WebApplicationtest1.Models;
using WebApplicationtest1.ViewModels;

namespace WebApplicationtest1.Profiles
{
    public class FundCureDtoProfile: Profile
    {
        public FundCureDtoProfile()
        {
            CreateMap<Fund, FundTrendDto>();
            CreateMap<FundTrend, FundTrendDto>();
        }
    }
}
