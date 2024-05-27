using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Online_Pet_Store_Example.Model;

[Table("user_account")]
public partial class UserAccount
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_name")]
    [StringLength(50)]
    public string UserName { get; set; } = null!;

    [Column("customer_id")]
    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("UserAccounts")]
    public virtual Customer Customer { get; set; } = null!;
}
