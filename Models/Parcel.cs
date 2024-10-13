using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CargoManagementSystem.Models;

[Table("parcel")]
[Index("TrackingId", Name = "UQ__parcel__7AC3E9AF6CA7E7C5", IsUnique = true)]
public partial class Parcel
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("tracking_id")]
    [StringLength(255)]
    [Unicode(false)]
    public string TrackingId { get; set; } = null!;

    [Column("customer_id")]
    public int? CustomerId { get; set; }

    [Column("parcel_type")]
    [StringLength(255)]
    [Unicode(false)]
    public string? ParcelType { get; set; }

    [Column("from_city_id")]
    public int? FromCityId { get; set; }

    [Column("to_city_id")]
    public int? ToCityId { get; set; }

    [Column("weight", TypeName = "decimal(10, 2)")]
    public decimal? Weight { get; set; }

    [Column("height", TypeName = "decimal(10, 2)")]
    public decimal? Height { get; set; }

    [Column("lenght", TypeName = "decimal(10, 2)")]
    public decimal? Lenght { get; set; }

    [Column("width", TypeName = "decimal(10, 2)")]
    public decimal? Width { get; set; }

    [Column("price", TypeName = "decimal(10, 2)")]
    public decimal? Price { get; set; }

    [Column("status", TypeName = "text")]
    public string Status { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("Parcel")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [ForeignKey("CustomerId")]
    [InverseProperty("Parcels")]
    public virtual Customer? Customer { get; set; }

    [ForeignKey("FromCityId")]
    [InverseProperty("ParcelFromCities")]
    public virtual City? FromCity { get; set; }

    [InverseProperty("Parcel")]
    public virtual ICollection<Parcelstatus> Parcelstatuses { get; set; } = new List<Parcelstatus>();

    [ForeignKey("ToCityId")]
    [InverseProperty("ParcelToCities")]
    public virtual City? ToCity { get; set; }
}
