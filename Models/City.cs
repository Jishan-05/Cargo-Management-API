using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CargoManagementSystem.Models;

[Table("city")]
public partial class City
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Address { get; set; } = null!;

    [Column("state_id")]
    public int? StateId { get; set; }

    [InverseProperty("FromCity")]
    public virtual ICollection<Deliveryroute> DeliveryrouteFromCities { get; set; } = new List<Deliveryroute>();

    [InverseProperty("ToCity")]
    public virtual ICollection<Deliveryroute> DeliveryrouteToCities { get; set; } = new List<Deliveryroute>();

    [InverseProperty("FromCity")]
    public virtual ICollection<Parcel> ParcelFromCities { get; set; } = new List<Parcel>();

    [InverseProperty("ToCity")]
    public virtual ICollection<Parcel> ParcelToCities { get; set; } = new List<Parcel>();

    [ForeignKey("StateId")]
    [InverseProperty("Cities")]
    public virtual State? State { get; set; }
}
