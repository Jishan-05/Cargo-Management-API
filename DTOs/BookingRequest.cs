namespace CargoManagementSystem.DTOs
{
    public class BookingRequest
    {
        public int PickAddressId { get; set; }
        public int DeliverAddressId { get; set; }
        public string ParcelType { get; set; }
        public string PaymentType { get; set; }
        public string Action { get; set; }

        // Add the city names to the DTO
        public string PickCityName { get; set; }
        public string DeliverCityName { get; set; }
    }
}
