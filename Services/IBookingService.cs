using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
public interface IBookingService
{
    Task<IEnumerable<BookingListDto>> GetBookingsAsync();
    Task<Booking> AddBookingAsync(AddBookingDto addBookingDto);
    Task UpdateBookingStatusAsync(int bookingId, string status, int userId);
    Task<decimal> CalculateEstimateAsync(string pickCityName, string deliverCityName, string parcelType);
    
}
