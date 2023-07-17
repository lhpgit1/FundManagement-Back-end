using WebApplicationtest1.Models;

namespace WebApplicationtest1.Data.Repositories
{
    public interface ITransRecordRepository
    {
        Task<IEnumerable<TranscationRecord>> GetTransRecordByFundIdAndDateAsync(int fundId, DateTime date);

    }
}
