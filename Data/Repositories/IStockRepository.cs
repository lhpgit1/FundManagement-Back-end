using WebApplicationtest1.Models;

namespace WebApplicationtest1.Data.Repositories
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetAllStocksAsync();
        Task<Stock> GetStockByIdAsync(int stockId);
        Task<IEnumerable<Stock>> GetStocksByIdsAsync(IEnumerable<int> stockIds);
        Task AddStockAsync(Stock stock);
        Task DeleteStockAsync(int stockId);
    }
}
