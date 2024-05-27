using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Online_Pet_Store_Example.Model;

[Table("stock")]
public partial class Stock
{
    /// <summary>
    /// should be same Id as item.
    /// </summary>
    [Key]
    [Column("itemid")]
    public int Itemid { get; set; }

    [Column("stock_amount")]
    public int StockAmount { get; set; }
}
