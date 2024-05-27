using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Online_Pet_Store_Example.Model;

[Table("customer")]
public partial class Customer
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("surname")]
    [StringLength(100)]
    public string Surname { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column("image")]
    public byte[]? Image { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<PurchaseLog> PurchaseLogs { get; set; } = new List<PurchaseLog>();

    [InverseProperty("Customer")]
    public virtual ICollection<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
}
