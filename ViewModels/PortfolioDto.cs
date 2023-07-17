using System.ComponentModel.DataAnnotations;

namespace WebApplicationtest1.ViewModels
{
    public class PortfolioDto
    {
        public int PortfolioId { get; set; }  
        public string FundName { get; set; }  //来自Models中的Fund
        public string StockName { get; set; } //来自Models中的Stock
        public string StockType { get; set; } //来自Models中的Stock
        public long HoldingQuantity { get; set; } 
        public decimal PurchaseCoast { get; set; }

        [DataType(DataType.Date)]
        public DateTime HolidingDate { get; set; }
        public decimal StockDailyCloseprice { get; set; }  //来自Models中的StockTrend

    }
}
