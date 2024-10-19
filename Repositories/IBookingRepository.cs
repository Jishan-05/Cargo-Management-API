using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBookingRepository
{
    Task<IEnumerable<Booking>> GetBookingsAsync();
    Task<Booking> AddBookingAsync(Booking booking);
    Task<Booking> GetBookingByIdAsync(int bookingId);
    
}
