using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CargoManagementSystem.Models;

[Table("pricing")]
public partial class Pricing
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("base_price", TypeName = "decimal(10, 2)")]
    public decimal? BasePrice { get; set; }

    [Column("price_per_km", TypeName = "decimal(10, 2)")]
    public decimal? PricePerKm { get; set; }

    [Column("price_per_kg", TypeName = "decimal(10, 2)")]
    public decimal? PricePerKg { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}
