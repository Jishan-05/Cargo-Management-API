public class MyBookingDto
{
    public string TrackingId { get; set; }
    public string ParcelType { get; set; }
    public decimal AmountPaid { get; set; }
    public string PaymentStatus { get; set; }
    public string Status { get; set; }
    public DateTime? BookingDate { get; set; }
    public int Id { get; set; }
}
