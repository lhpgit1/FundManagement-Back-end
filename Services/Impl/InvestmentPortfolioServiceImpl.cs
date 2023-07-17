using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using WebApplicationtest1.Data.Repositories;
using WebApplicationtest1.Data.Repositories.Impl;
using WebApplicationtest1.Models;
using WebApplicationtest1.ViewModels;

namespace WebApplicationtest1.Services.Impl
{
    public class InvestmentPortfolioServiceImpl : IInvestmentPortfolioService
    {
        private readonly IInvestmentPortfolioRepository _portfoliorepository;
        private readonly IFundRepository _fundrepository;
        private readonly IStockRepository _stockrepository;
        private readonly IStockTrendRepository _stocktrendrepository;

        private readonly IMapper _mapper;
        public InvestmentPortfolioServiceImpl(IInvestmentPortfolioRepository portfoliorepository, IFundRepository fundrepository, IStockRepository stockrepository, IStockTrendRepository stocktrendrepository, IMapper mapper)
        {
            _portfoliorepository = portfoliorepository;
            _fundrepository = fundrepository;
            _stockrepository = stockrepository;
            _stocktrendrepository=stocktrendrepository;

           _mapper = mapper;
        }
        public async Task<IEnumerable<InvestmentPortfolio>> GetAllPortfolios()
        {
            return await _portfoliorepository.GetAllPortfoliosAsync();
        }
        public async Task<IEnumerable<InvestmentPortfolio>> GetPortfolioByFundId(int fundId)
        {
            return await _portfoliorepository.GetPortfolioByFundIdAsync(fundId);
        }
        public async Task<IEnumerable<InvestmentPortfolio>> GetPortfolioByStockId(int stockId)
        {
            return await _portfoliorepository.GetPortfolioByStockIdAsync(stockId);
        }
        public async Task AddPortfolio(InvestmentPortfolio portfolio)
        {
            await _portfoliorepository.AddPortfolioAsync(portfolio);
        }
        public async Task DeletePortfolioByPortfolioId(int portfolioId)
        {
            await _portfoliorepository.DeletePortfolioByPortfolioIdAsync(portfolioId);
        }

        //实现根据前端传来的基金名称和时间参数，显示对应的投资组合
        public async Task<IEnumerable<PortfolioDto>> GetPortfolioByFundNameAndTime(String fundName, DateTime date)
        {
            //根据传来的参数fundName找到fundId
            var fundId = await _fundrepository.GetFundIdByFundNameAsync(fundName);
            //根据fundId和传来的参数date找到对应的投资组合
            var investPortfolios = await _portfoliorepository.GetPortfolioByFundIdAndDateAsync(fundId, date);
            //筛选出stockid
            var stockIds = investPortfolios.Select(p => p.StockId).Distinct().ToList();

            var stocks = await _stockrepository.GetStocksByIdsAsync(stockIds);
            var stocktrends=await _stocktrendrepository.GetStockTrendsByIdsAndDateAsync(stockIds, date);

            var stockDictionary = stocks.ToDictionary(stock => stock.StockId);

            var stocktrendDictionary = stocktrends.ToDictionary(stocktrend => stocktrend.StockId);

            var portfolioDtoList = new List<PortfolioDto>();

            foreach (var item in investPortfolios)
            {
                if (stockDictionary.TryGetValue(item.StockId, out var stock)&& stocktrendDictionary.TryGetValue(item.StockId, out var stocktrend))
                {
                    var portfolioDto = new PortfolioDto
                    {
                        PortfolioId = item.PortfolioId,
                        FundName = fundName,
                        StockName = stock.StockName,
                        StockType = stock.StockType,
                        HoldingQuantity = item.HoldingQuantity,
                        PurchaseCoast = item.PurchaseCoast,
                        HolidingDate = item.HolidingDate,
                        StockDailyCloseprice =stocktrend.StockDailyCloseprice,
                    };

                    portfolioDtoList.Add(portfolioDto);
                }
            }

            return portfolioDtoList;

        }

    }
}
