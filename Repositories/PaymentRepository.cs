using CargoManagementSystem.Data;
using CargoManagementSystem.Repositories;
using CargoManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PaymentRepository : IPaymentRepository
{
    private readonly AppDbContext _context;

    public PaymentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Booking>> GetPendingPaymentsAsync()
    {
        return await _context.Bookings
            .FromSqlRaw("SELECT * FROM booking WHERE CAST(payment_status AS VARCHAR(MAX)) = 'Pending'")
            .Include(b => b.Parcel)
            .Include(b => b.Customer)
                .ThenInclude(c => c.User)
            .ToListAsync();
    }
    
    public async Task<Booking> GetBookingByIdAsync(int id)
    {
        return await _context.Bookings
            .Include(b => b.Customer).ThenInclude(c => c.User)
            .Include(b => b.Parcel).ThenInclude(p => p.FromCity)
            .Include(b => b.Parcel).ThenInclude(p => p.ToCity)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<bool> AcceptPaymentAsync(int bookingId, int userId)
    {
        var booking = await GetBookingByIdAsync(bookingId);
        if (booking == null) return false;

        // Update parcel and payment status
        var parcel = booking.Parcel;
        parcel.Status = "Booked";
        parcel.UpdatedAt = DateTime.Now;

        booking.BookingDate = DateTime.Now;
        booking.AmountPaid = parcel.Price;
        booking.PaymentStatus = "Accepted";

        // Add parcel status update
        var parcelStatus = new Parcelstatus()
        {
            ParcelId = parcel.Id,
            Status = $"Parcel arrived at {parcel.FromCity.Name}",
            UpdateByUserId = userId,
            UpdatedAt = DateTime.Now
        };
        _context.Parcelstatuses.Add(parcelStatus);

        await _context.SaveChangesAsync();
        return true;
    }


}
