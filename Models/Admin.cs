using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CargoManagementSystem.Models;

[Table("admin")]
public partial class Admin
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("phone_number")]
    [StringLength(20)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [Column("address", TypeName = "text")]
    public string Address { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Admins")]
    public virtual User? User { get; set; }
}
