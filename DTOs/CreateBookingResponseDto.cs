public class CreateBookingResponseDto
{
    public int Id { get; set; }
    public int? CustomerId { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerPhone { get; set; }
    public string? CustomerAddress { get; set; }
    public string? PickCityName { get; set; }
    public string? DeliverCityName { get; set; }
    public string? ParcelType { get; set; }
    public string? Status { get; set; }
    public decimal? Price { get; set; }
    public string? TrackingId { get; set; }
    public DateTime? BookingDate { get; set; }
    public decimal? AmountPaid { get; set; }
    public string? PaymentStatus { get; set; }
}
