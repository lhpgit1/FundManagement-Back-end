using System;
using System.Collections.Generic;

namespace WebApplicationtest1.Models;

public partial class InvestmentPortfolio
{
    public int PortfolioId { get; set; }

    public int FundId { get; set; }

    public int StockId { get; set; }

    public long HoldingQuantity { get; set; }

    public decimal PurchaseCoast { get; set; }

    public DateTime HolidingDate { get; set; }
}
