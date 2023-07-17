using WebApplicationtest1.Models;
namespace WebApplicationtest1.Data.Repositories
{
    public interface IInvestmentPortfolioRepository
    {
        Task<IEnumerable<InvestmentPortfolio>> GetAllPortfoliosAsync();
        Task<IEnumerable<InvestmentPortfolio>> GetPortfolioByFundIdAsync(int fundId);
        Task<IEnumerable<InvestmentPortfolio>> GetPortfolioByStockIdAsync(int stockId);

        Task<IEnumerable<InvestmentPortfolio>> GetPortfolioByFundIdAndDateAsync(int fundId,DateTime date);

        Task AddPortfolioAsync(InvestmentPortfolio portfolio);

        Task DeletePortfolioByPortfolioIdAsync(int portfolioId);
    }
}
