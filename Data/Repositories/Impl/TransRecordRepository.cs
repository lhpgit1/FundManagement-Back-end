using Microsoft.EntityFrameworkCore;
using WebApplicationtest1.Models;

namespace WebApplicationtest1.Data.Repositories.Impl
{
    public class TransRecordRepository: ITransRecordRepository
    {
        private readonly FundmanagementDbContext db;
        public TransRecordRepository(FundmanagementDbContext dbContext)
        {
            db = dbContext;
        }
        public async Task<IEnumerable<TranscationRecord>> GetTransRecordByFundIdAndDateAsync(int fundId, DateTime date) {
            return await db.TranscationRecords.Where(f => f.FundId == fundId && f.TransDate == date)
        .ToListAsync();
        }
    }
}
