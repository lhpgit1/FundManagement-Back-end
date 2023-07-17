using WebApplicationtest1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationtest1.Data.Repositories.Impl
{
    public class StockRepository : IStockRepository
    {
        private readonly FundmanagementDbContext db;

        public StockRepository(FundmanagementDbContext dbContext)
        {
            db = dbContext;
        }
        public async Task<IEnumerable<Stock>> GetAllStocksAsync()
        {
            return await db.Stocks.ToListAsync();
        }
        public async Task<Stock> GetStockByIdAsync(int stockId)
        {
            return await db.Stocks.FirstOrDefaultAsync(s => s.StockId == stockId);
        }
        public async Task<IEnumerable<Stock>> GetStocksByIdsAsync(IEnumerable<int> stockIds)
        {
            var stocks = await db.Stocks.Where(s => stockIds.Contains(s.StockId)).ToListAsync();
            return stocks;
        }

        public async Task AddStockAsync(Stock stock)
        {
            db.Stocks.Add(stock);
            await db.SaveChangesAsync();
        }
        public async Task DeleteStockAsync(int stockId)
        {
            Stock existingStock = await db.Stocks.FirstOrDefaultAsync(s => s.StockId == stockId);
            if (existingStock != null)
            {
                db.Stocks.Remove(existingStock);
                await db.SaveChangesAsync();
            }
        }
    }
}
