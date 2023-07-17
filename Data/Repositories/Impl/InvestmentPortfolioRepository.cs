using System.Threading.Tasks;
using WebApplicationtest1.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections;

namespace WebApplicationtest1.Data.Repositories.Impl;

public class InvestmentPortfolioRepository : IInvestmentPortfolioRepository
{
    private readonly FundmanagementDbContext db;
    public InvestmentPortfolioRepository(FundmanagementDbContext dbContext)
    {
        db = dbContext;
    }
    public async Task<IEnumerable<InvestmentPortfolio>> GetAllPortfoliosAsync()
    {
        return await db.InvestmentPortfolios.ToListAsync();
    }
    public async Task<IEnumerable<InvestmentPortfolio>> GetPortfolioByFundIdAsync(int id)
    {
        return await db.InvestmentPortfolios.Where(f => f.FundId == id).ToListAsync();
    }
    public async Task<IEnumerable<InvestmentPortfolio>> GetPortfolioByStockIdAsync(int id)
    {
        return await db.InvestmentPortfolios.Where(f => f.StockId == id).ToListAsync();
    }
    public async Task<IEnumerable<InvestmentPortfolio>> GetPortfolioByFundIdAndDateAsync(int fundId, DateTime date)
    {
        return await db.InvestmentPortfolios.Where(f => f.FundId == fundId && f.HolidingDate == date)
        .ToListAsync();
    }
    public async Task AddPortfolioAsync(InvestmentPortfolio portfolio)
    {
        db.InvestmentPortfolios.Add(portfolio);
        await db.SaveChangesAsync();
    }
    public async Task DeletePortfolioByPortfolioIdAsync(int id)
    {
        InvestmentPortfolio existingPortfolio = await db.InvestmentPortfolios.FirstOrDefaultAsync(s => s.PortfolioId == id);
        if (existingPortfolio != null)
        {
            db.InvestmentPortfolios.Remove(existingPortfolio);
            await db.SaveChangesAsync();
        }
    }



}


