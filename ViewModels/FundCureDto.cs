using System.ComponentModel.DataAnnotations;

namespace WebApplicationtest1.ViewModels
{
    public class FundCureDto
    {
        public string FundName { get; set; }

        public decimal FundLatestnetworth { get; set; }
        [DataType(DataType.Date)]

        public DateTime FtrendDate { get; set; }

    }
}
