using WebApplicationtest1.Models;

namespace WebApplicationtest1.Services
{
    public interface IStockService
    {
        Task<IEnumerable<Stock>> GetAllStocks();
        Task<Stock> GetStockById(int stockId);
        Task AddStock(Stock stock);
        Task DeleteStock(int stockId);
    }
}
