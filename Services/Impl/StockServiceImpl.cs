using WebApplicationtest1.Data.Repositories;
using WebApplicationtest1.Models;

namespace WebApplicationtest1.Services.Impl
{
    public class StockServiceImpl : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockServiceImpl(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        public async Task<IEnumerable<Stock>> GetAllStocks()
        {
            return await _stockRepository.GetAllStocksAsync();
        }
        public async Task<Stock> GetStockById(int id)
        {
            return await _stockRepository.GetStockByIdAsync(id);
        }
        public async Task AddStock(Stock stock)
        {
            await _stockRepository.AddStockAsync(stock);
        }
        public async Task DeleteStock(int id)
        {
            await _stockRepository.DeleteStockAsync(id);
        }
    }
}
