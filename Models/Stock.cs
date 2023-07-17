using System;
using System.Collections.Generic;

namespace WebApplicationtest1.Models;

public partial class Stock
{
    public int StockId { get; set; }

    public string StockName { get; set; } = null!;

    public string StockType { get; set; } = null!;
}
