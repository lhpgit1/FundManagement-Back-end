using WebApplicationtest1.Models;
using WebApplicationtest1.ViewModels;

namespace WebApplicationtest1.Services
{
    public interface IFundService
    {
        Task<IEnumerable<Fund>> GetAllFunds();
        Task<Fund> GetFundById(int id);
        Task<IEnumerable<FundCureDto>> GetAllFundCure();

        Task<IEnumerable<FundTrendDto>> GetAllFundTrendByDate(DateTime date);
    }
}
