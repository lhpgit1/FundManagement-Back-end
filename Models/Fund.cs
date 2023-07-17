using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationtest1.Models;

public partial class Fund
{
    public string FundName { get; set; } = null!;

    public decimal? FundInitialassets { get; set; }

    public long FundShare { get; set; }

    public int FundId { get; set; }

    [DataType(DataType.Date)]
    public DateTime? FundEstablishDate { get; set; }

    public decimal? FundInitialPrice { get; set; }

    public string? FundType { get; set; }

    public string? FundManager { get; set; }

    [DataType(DataType.Date)]
    public DateTime? FundRedemptionOpenDay { get; set; }
}
