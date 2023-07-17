using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationtest1.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationtest1.Data.Repositories.Impl;

public class FundRepository : IFundRepository
{
    private readonly FundmanagementDbContext db;
    public FundRepository(FundmanagementDbContext dbContext)
    {
        db = dbContext;
    }
    public async Task<IEnumerable<Fund>> GetAllFundsAsync()
    {
        return await db.Funds.ToListAsync();

    }

    public async Task<IEnumerable<Fund>> GetAllFundsByFundIdsAsync(IEnumerable<int> fundIds)
    {
        var funds = await db.Funds.Where(s => fundIds.Contains(s.FundId)).ToListAsync();
        return funds;
    }

    public async Task<Fund> GetFundByIdAsync(int id)
    {
        return await db.Funds.FirstOrDefaultAsync(f => f.FundId == id);
    }
    public async Task<int> GetFundIdByFundNameAsync(string name)
    {
        var fund = await db.Funds.FirstOrDefaultAsync(f => f.FundName == name);
        return fund?.FundId ?? 0;
    }
}
