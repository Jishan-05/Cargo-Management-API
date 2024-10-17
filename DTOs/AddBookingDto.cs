public class AddBookingDto
{
    public string CustomerEmail { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public string PickCityName { get; set; }  // Keep this instead of PickAddressId
    public string DeliverCityName { get; set; }  // Keep this instead of DeliverAddressId
    public string ParcelType { get; set; }
    public string PaymentType { get; set; } = "cod"; // default to COD
    public string Action { get; set; }
}
