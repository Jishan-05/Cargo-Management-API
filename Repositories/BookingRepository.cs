using CargoManagementSystem.Data;
using CargoManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _context;

    public BookingRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Booking>> GetBookingsAsync()
    {
        return await _context.Bookings
            .Include(b => b.Customer)
            .Include(b => b.Parcel)
            .ToListAsync();
    }

    public async Task<Booking> AddBookingAsync(Booking booking)
    {
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
        return booking;
    }

    public async Task<Booking> GetBookingByIdAsync(int id)
    {
        return await _context.Bookings.Include(b => b.Customer).ThenInclude(c => c.User)
                                    .Include(b => b.Parcel).ThenInclude(p => p.FromCity)
                                    .Include(b => b.Parcel).ThenInclude(p => p.ToCity)
                                    .FirstOrDefaultAsync(b => b.Id == id);
    }


    

   
}
