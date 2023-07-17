using Microsoft.EntityFrameworkCore;
using WebApplicationtest1.Models;

namespace WebApplicationtest1.Data.Repositories.Impl
{
    public class FundTrendRepository:IFundTrendRepository
    {
        private readonly FundmanagementDbContext db;
        public FundTrendRepository(FundmanagementDbContext dbContext)
        {
            db = dbContext;
        }

        async Task<IEnumerable<FundTrend>> IFundTrendRepository.GetAllFundTrendAsync()
        {
            return await db.FundTrends.ToListAsync();
        }

        Task<IEnumerable<FundTrend>> IFundTrendRepository.GetFundTrendByFundIdAsync(int funId)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<FundTrend>> IFundTrendRepository.GetFundTrendByDateAsync(DateTime date)
        {
            return await db.FundTrends.Where(t => t.FtrendDate == date)
                .ToListAsync();
        }

        Task<IEnumerable<FundTrend>> IFundTrendRepository.GetFundTrendByFundIdAndDateAsync(int funId, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
