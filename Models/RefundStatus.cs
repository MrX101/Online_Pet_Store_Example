using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Online_Pet_Store_Example.Model;

[Table("refund_status")]
public partial class RefundStatus
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("RefundStatus")]
    public virtual ICollection<RefundLog> RefundLogs { get; set; } = new List<RefundLog>();
}
