using WebApplicationtest1.Models;

namespace WebApplicationtest1.Data.Repositories
{
    public interface IStockTrendRepository
    {
        Task<IEnumerable<StockTrend>> GetStockTrendsByIdsAndDateAsync(IEnumerable<int> stockIds,DateTime date);
    }
}
