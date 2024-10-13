using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CargoManagementSystem.Models;

[Table("deliveryroute")]
public partial class Deliveryroute
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("from_city_id")]
    public int? FromCityId { get; set; }

    [Column("to_city_id")]
    public int? ToCityId { get; set; }

    [Column("distance_km", TypeName = "decimal(10, 2)")]
    public decimal? DistanceKm { get; set; }

    [ForeignKey("FromCityId")]
    [InverseProperty("DeliveryrouteFromCities")]
    public virtual City? FromCity { get; set; }

    [ForeignKey("ToCityId")]
    [InverseProperty("DeliveryrouteToCities")]
    public virtual City? ToCity { get; set; }
}
