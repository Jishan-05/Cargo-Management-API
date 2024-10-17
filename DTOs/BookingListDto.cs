// BookingListDto.cs
public class BookingListDto
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string ParcelType { get; set; }
    public DateTime BookingDate { get; set; }
    public decimal AmountPaid { get; set; }
    public string PaymentStatus { get; set; }
    public string ParcelStatus { get; set; }
}
    