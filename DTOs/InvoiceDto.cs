using CargoManagementSystem.DTOs;

namespace CargoManagementSystem.DTOs
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Price { get; set; }
        public DateTime CreatedOn { get; set; }
        public int BookingId { get; set; }
        public BookingListDto Booking { get; set; } = null!;
    }
    
}
