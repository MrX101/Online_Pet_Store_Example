using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Online_Pet_Store_Example.Model;

[Table("brand")]
public partial class Brand
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [InverseProperty("Brand")]
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
