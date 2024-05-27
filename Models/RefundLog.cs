using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Online_Pet_Store_Example.Model;

[Table("refund_log")]
public partial class RefundLog
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("purchase_log_id")]
    public int PurchaseLogId { get; set; }

    [Column("date_time_of_refund")]
    public DateOnly DateTimeOfRefund { get; set; }

    [Column("refund_status_id")]
    public int RefundStatusId { get; set; }

    [ForeignKey("PurchaseLogId")]
    [InverseProperty("RefundLogs")]
    public virtual PurchaseLog PurchaseLog { get; set; } = null!;

    [ForeignKey("RefundStatusId")]
    [InverseProperty("RefundLogs")]
    public virtual RefundStatus RefundStatus { get; set; } = null!;
}
