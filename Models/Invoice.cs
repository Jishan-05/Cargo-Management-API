using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CargoManagementSystem.Models;

[Table("invoice")]
public partial class Invoice
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public DateOnly CreatedOn { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string CustmerName { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Price { get; set; } = null!;

    public int BookingId { get; set; }

    [ForeignKey("BookingId")]
    [InverseProperty("Invoices")]
    public virtual Booking Booking { get; set; } = null!;
}
