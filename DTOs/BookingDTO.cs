public class BookingDto
{
    public int Id { get; set; }
    public string? CustomerName { get; set; }
    public string? ParcelType { get; set; }
    public string? FromCityName { get; set; }
    public string? ToCityName { get; set; }
    public decimal AmountPaid { get; set; }
    public DateTime BookingDate { get; set; }
}
