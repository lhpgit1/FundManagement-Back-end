using WebApplicationtest1.Data.Repositories;
using WebApplicationtest1.Data.Repositories.Impl;
using WebApplicationtest1.Models;
using WebApplicationtest1.ViewModels;

namespace WebApplicationtest1.Services.Impl
{
    public class FundServiceImpl : IFundService
    {
        private readonly IFundRepository _fundRepository;
        private readonly IFundTrendRepository _fundTrendRepository;

        public FundServiceImpl(IFundRepository fundRepository, IFundTrendRepository fundTrendRepository)
        {
            _fundRepository = fundRepository;
            _fundTrendRepository=fundTrendRepository;
        }

        public async Task<IEnumerable<FundCureDto>> GetAllFundCure()
        {
            var fundTrends = await _fundTrendRepository.GetAllFundTrendAsync();
            var funds=await _fundRepository.GetAllFundsAsync();
            var fundIds = funds.Select(f => f.FundId).Distinct().ToList();
            var fundDictionary = funds.ToDictionary(fund => fund.FundId);
            var fundcureDtoList = new List<FundCureDto>();

            foreach (var item in fundTrends)
            {
                if (fundDictionary.TryGetValue(item.FundId, out var fund))
                {
                    var fundcureDto = new FundCureDto
                    {
                        FundName = fund.FundName,
                        FtrendDate=item.FtrendDate,
                        FundLatestnetworth=item.FundLatestnetworth,
                        
                    };

                    fundcureDtoList.Add(fundcureDto);
                }
            }

            return fundcureDtoList;
        }

        public async Task<IEnumerable<Fund>> GetAllFunds()
        {

            return await _fundRepository.GetAllFundsAsync();
        }

        public async Task<IEnumerable<FundTrendDto>> GetAllFundTrendByDate(DateTime date)
        {
            var fundTrends= await _fundTrendRepository.GetFundTrendByDateAsync(date);
            var fundIds = fundTrends.Select(p => p.FundId).Distinct().ToList();
            var funds = await _fundRepository.GetAllFundsByFundIdsAsync(fundIds);
            var fundDictionary = funds.ToDictionary(fund => fund.FundId);
            var fundTrendDtoDtoList = new List<FundTrendDto>();
            foreach (var item in fundTrends)
            {
                if (fundDictionary.TryGetValue(item.FundId, out var fund))
                {
                    var fundTrendDto = new FundTrendDto
                    {
                        FundName=fund.FundName,
                        FundInitialassets=fund.FundInitialassets,
                        FundShare=fund.FundShare,
                        FundInitialPrice=fund.FundInitialPrice,
                        FundLatestnetworth=item.FundLatestnetworth,
                        FtrendDate=item.FtrendDate

                    };

                    fundTrendDtoDtoList.Add(fundTrendDto);
                }
            }
            return fundTrendDtoDtoList;

        }

        public async Task<Fund> GetFundById(int id)
        {
            return await _fundRepository.GetFundByIdAsync(id);
        }
      



    }
}
