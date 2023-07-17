using System.Collections.Generic;
using WebApplicationtest1.Models;


namespace WebApplicationtest1.Data.Repositories
{
    public interface IFundRepository
    {
        Task<IEnumerable<Fund>> GetAllFundsAsync();

        Task<IEnumerable<Fund>> GetAllFundsByFundIdsAsync(IEnumerable<int> fundIds);
        Task<Fund> GetFundByIdAsync(int id);

        //通过FundName查询FundId
        Task<int> GetFundIdByFundNameAsync(string fundName);

    }
}
 