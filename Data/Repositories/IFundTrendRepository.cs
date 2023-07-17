using WebApplicationtest1.Models;

namespace WebApplicationtest1.Data.Repositories
{
    public interface IFundTrendRepository
    {
        Task<IEnumerable<FundTrend>> GetAllFundTrendAsync();

        Task<IEnumerable<FundTrend>> GetFundTrendByFundIdAsync(int funId);

        Task<IEnumerable<FundTrend>> GetFundTrendByDateAsync(DateTime date);

        Task<IEnumerable<FundTrend>> GetFundTrendByFundIdAndDateAsync(int funId,DateTime date);

    }
}
