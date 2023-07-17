using Microsoft.EntityFrameworkCore;
using WebApplicationtest1.Models;

namespace WebApplicationtest1.Data.Repositories.Impl
{
    public class StockTrendRepository : IStockTrendRepository
    {
        private readonly FundmanagementDbContext db;
        public StockTrendRepository(FundmanagementDbContext dbContext)
        {
            db = dbContext;
        }
        public async Task<IEnumerable<StockTrend>> GetStockTrendsByIdsAndDateAsync(IEnumerable<int> stockIds, DateTime date)
        {
            return await db.StockTrends.Where(t => stockIds.Contains(t.StockId)).Where(t => t.StrendDate == date).ToListAsync();
        }



    }
}
