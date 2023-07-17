using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationtest1.Models;

public partial class TranscationRecord
{
    public int TranscationId { get; set; }

    public int FundId { get; set; }

    public int StockId { get; set; }

    public long TransQuantity { get; set; }

    public string TransType { get; set; } = null!;

    [DataType(DataType.Date)]
    public DateTime TransDate { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TransAmount { get; set; }

}
