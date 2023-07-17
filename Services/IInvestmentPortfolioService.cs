using WebApplicationtest1.Models;
using WebApplicationtest1.ViewModels;

namespace WebApplicationtest1.Services
{
    public interface IInvestmentPortfolioService
    {
        Task<IEnumerable<InvestmentPortfolio>> GetAllPortfolios();
        //通过FundId查找投资组合记录
        Task<IEnumerable<InvestmentPortfolio>> GetPortfolioByFundId(int fundId);
        //通过StockId查找投资组合记录
        Task<IEnumerable<InvestmentPortfolio>> GetPortfolioByStockId(int stockId);
        Task AddPortfolio(InvestmentPortfolio portfolio);

        Task DeletePortfolioByPortfolioId(int portfolioId);
        //通过FundName和Time来查找某一基金特定时间的投资组合
        Task<IEnumerable<PortfolioDto>> GetPortfolioByFundNameAndTime(String fundName, DateTime date);
    }
}
