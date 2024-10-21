namespace CargoManagementSystem.DTOs
{    
   public class PaymentDto
    {
        public int BookingId { get; set; }
        public string TrackingId { get; set; }
        public string PaymentStatus { get; set; }
        public string ParcelType { get; set; }
        public decimal Price { get; set; }
        public string CustomerName { get; set; }
    }
}
