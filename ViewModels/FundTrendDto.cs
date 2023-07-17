using System.ComponentModel.DataAnnotations;

namespace WebApplicationtest1.ViewModels
{
    public class FundTrendDto
    {

        public string FundName { get; set; }
        public decimal? FundInitialassets { get; set; }

        public long FundShare { get; set; }

        public decimal? FundInitialPrice { get; set; }

        public decimal FundLatestnetworth { get; set; }
        [DataType(DataType.Date)]
        public DateTime FtrendDate { get; set; }
    }
}
