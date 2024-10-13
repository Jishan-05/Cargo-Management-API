using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CargoManagementSystem.Models;

[Table("parcelstatus")]
public partial class Parcelstatus
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("parcel_id")]
    public int? ParcelId { get; set; }

    [Column("status", TypeName = "text")]
    public string Status { get; set; } = null!;

    [Column("update_by_user_id")]
    public int UpdateByUserId { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("ParcelId")]
    [InverseProperty("Parcelstatuses")]
    public virtual Parcel? Parcel { get; set; }

    [ForeignKey("UpdateByUserId")]
    [InverseProperty("Parcelstatuses")]
    public virtual User UpdateByUser { get; set; } = null!;
}
