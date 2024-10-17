using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
public interface IBookingService
{
    Task<IEnumerable<BookingListDto>> GetBookingsAsync();
    Task<Booking> AddBookingAsync(AddBookingDto addBookingDto);
    Task<decimal> CalculateEstimateAsync(string pickCityName, string deliverCityName, string parcelType);
}
