using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Online_Pet_Store_Example.Model;

[Table("purchase_log")]
public partial class PurchaseLog
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("amount")]
    public int Amount { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("PurchaseLogs")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("ItemId")]
    [InverseProperty("PurchaseLogs")]
    public virtual Item Item { get; set; } = null!;

    [InverseProperty("PurchaseLog")]
    public virtual ICollection<RefundLog> RefundLogs { get; set; } = new List<RefundLog>();
}
