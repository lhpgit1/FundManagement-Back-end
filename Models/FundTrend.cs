using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationtest1.Models;

public partial class FundTrend
{
    public int FtrendId { get; set; }

    public int FundId { get; set; }

    public decimal FundLatestnetworth { get; set; }
    [DataType(DataType.Date)]
    public DateTime FtrendDate { get; set; }
}
