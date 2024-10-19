namespace CargoManagementSystem.Models
{
    public class ParcelDto
    {
        public int Id { get; set; }  // Add the Parcel Id
        public string CustomerName { get; set; }
        public string TrackingId { get; set; }
        public string ParcelType { get; set; }
        public string Status { get; set; }
    }
}
