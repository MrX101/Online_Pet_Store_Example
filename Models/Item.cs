using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Online_Pet_Store_Example.Model;

[Table("item")]
public partial class Item
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("image")]
    [StringLength(100)]
    public string? Image { get; set; }

    [Column("serial_number")]
    [StringLength(50)]
    public string SerialNumber { get; set; } = null!;

    [Column("brand_id")]
    public int BrandId { get; set; }

    [ForeignKey("BrandId")]
    [InverseProperty("Items")]
    public virtual Brand Brand { get; set; } = null!;

    [InverseProperty("Item")]
    public virtual ICollection<PurchaseLog> PurchaseLogs { get; set; } = new List<PurchaseLog>();
}
