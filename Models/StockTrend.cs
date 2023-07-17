using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationtest1.Models;

public partial class StockTrend
{
    public int StrendId { get; set; }

    public int StockId { get; set; }

    public decimal StockDailyCloseprice { get; set; }
    [DataType(DataType.Date)]
    public DateTime StrendDate { get; set; }
}
