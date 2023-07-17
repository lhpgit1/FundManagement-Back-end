using WebApplicationtest1.Models;
using WebApplicationtest1.ViewModels;

namespace WebApplicationtest1.Services
{
    public interface ITransRecordService
    {
        Task<IEnumerable<TransRecordDto>> GetTransRecordByFundNameAndDateAsync(string fundName, DateTime date);


    }
}
