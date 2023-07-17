using System.ComponentModel.DataAnnotations;

namespace WebApplicationtest1.ViewModels
{
    public class TransRecordDto
    {
        public int TranscationId { get; set; }

        public string FundName { get; set; }

        public string StockName { get; set; }

        public long TransQuantity { get; set; }

        public string TransType { get; set; } = null!;

        [DataType(DataType.Date)]
        public DateTime TransDate { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TransAmount { get; set; }
    }
}
