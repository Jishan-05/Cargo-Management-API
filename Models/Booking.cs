using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CargoManagementSystem.Models;

[Table("booking")]
public partial class Booking
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("parcel_id")]
    public int? ParcelId { get; set; }

    [Column("customer_id")]
    public int? CustomerId { get; set; }

    [Column("booking_date", TypeName = "datetime")]
    public DateTime? BookingDate { get; set; }

    [Column("amount_paid", TypeName = "decimal(10, 2)")]
    public decimal? AmountPaid { get; set; }

    [Column("payment_status", TypeName = "text")]
    public string PaymentStatus { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Bookings")]
    public virtual Customer? Customer { get; set; }

    [InverseProperty("Booking")]
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    [ForeignKey("ParcelId")]
    [InverseProperty("Bookings")]
    public virtual Parcel? Parcel { get; set; }
}
