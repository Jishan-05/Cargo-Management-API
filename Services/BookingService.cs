using CargoManagementSystem.DTOs;
using CargoManagementSystem.Data;
using CargoManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using CargoManagementSystem.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly AppDbContext _context;  // Assuming a context for Pricing and City models

    public BookingService(IBookingRepository bookingRepository, AppDbContext context)
    {
        _bookingRepository = bookingRepository;
        _context = context;
    }

    // public async Task<IEnumerable<BookingListDto>> GetBookingsAsync()
    // {
    //     var bookings = await _bookingRepository.GetBookingsAsync();
        
    //     foreach (var booking in bookings)
    //     {
    //         if (booking.Customer == null)
    //         {
    //             Console.WriteLine("Customer is null for booking ID: " + booking.Id);
    //         }
    //         else if (booking.Customer.User == null)
    //         {
    //             Console.WriteLine("User is null for customer ID: " + booking.Customer.Id);
    //         }
    //         else
    //         {
    //             Console.WriteLine($"Customer: {booking.Customer.User.FirstName} {booking.Customer.User.LastName}");
    //         }
    //     }
        
    //     return bookings.Select(b => new BookingListDto
    //     {
    //         Id = b.Id,
    //         CustomerName = (b.Customer?.User?.FirstName ?? "") + " " + (b.Customer?.User?.LastName ?? ""),
    //         ParcelType = b.Parcel?.ParcelType ?? "Unknown",
    //         BookingDate = b.BookingDate ?? DateTime.Now,
    //         AmountPaid = b.AmountPaid ?? 0,
    //         PaymentStatus = b.PaymentStatus,
    //         ParcelStatus = b.Parcel?.Status ?? "Unknown"
    //     });
    // }

    public async Task<IEnumerable<BookingListDto>> GetBookingsAsync()
    {
        // Fetch the bookings, including related Customer and User entities
        var bookings = await _context.Bookings
            .Include(b => b.Customer)
                .ThenInclude(c => c.User) // Include User for the Customer
            .Include(b => b.Parcel)
            .Select(b => new BookingListDto
            {
                Id = b.Id,
                CustomerName = b.Customer.User.Username, // Displaying Username from User model
                ParcelType = b.Parcel.ParcelType,
                BookingDate = b.BookingDate ?? DateTime.Now,
                AmountPaid = b.AmountPaid ?? 0,
                PaymentStatus = b.PaymentStatus,
                ParcelStatus = b.Parcel.Status ?? "Unknown"
            })
            .ToListAsync();

        return bookings;
    }


    public async Task<Booking> AddBookingAsync(AddBookingDto addBookingDto)
    {
        // Fetch customer by email
        var customer = await _context.Customers
            .Include(c => c.User)
            .FirstOrDefaultAsync(c => c.User.Email == addBookingDto.CustomerEmail);

        if (customer == null) throw new Exception("Customer not found");

        // Fetch cities by name
        var pickCity = await _context.Cities
            .FirstOrDefaultAsync(c => c.Name == addBookingDto.PickCityName);

        var deliverCity = await _context.Cities
            .FirstOrDefaultAsync(c => c.Name == addBookingDto.DeliverCityName);

        if (pickCity == null || deliverCity == null)
            throw new Exception("Invalid city selected.");

        if (pickCity == deliverCity)
            throw new Exception("Pickup address and delivery address should not be the same.");

        // Pricing logic (unchanged)
        var pricing = await _context.Pricings.OrderByDescending(p => p.CreatedAt).FirstOrDefaultAsync();
        if (pricing == null) throw new Exception("Pricing details not available.");

        decimal basePrice = pricing.BasePrice ?? 0;
        decimal pricePerKm = pricing.PricePerKm ?? 0;

        var route = await _context.Deliveryroutes
            .FirstOrDefaultAsync(r => r.FromCityId == pickCity.Id && r.ToCityId == deliverCity.Id);

        if (route == null) throw new Exception("No delivery route found.");

        decimal estimatedPrice = await CalculateEstimateAsync(addBookingDto.PickCityName, addBookingDto.DeliverCityName, addBookingDto.ParcelType);

        // Create Parcel and Booking
        var parcel = new Parcel
        {
            TrackingId = Guid.NewGuid().ToString(),
            Customer = customer,
            ParcelType = addBookingDto.ParcelType,
            FromCity = pickCity,
            ToCity = deliverCity,
            Price = estimatedPrice,
            Status = "Booked",
            CreatedAt = DateTime.Now
        };

        var booking = new Booking
        {
            Parcel = parcel,
            Customer = customer,
            BookingDate = DateTime.Now,
            AmountPaid = estimatedPrice,
            PaymentStatus = "Accepted",
            CreatedAt = DateTime.Now
        };

        var booked = await _bookingRepository.AddBookingAsync(booking);

        return booked;
    }

    // public async Task<decimal> CalculateEstimateAsync(int pickCityId, int deliverCityId, string parcelType)
    // {
    //     var pickCity = await _context.Cities.FindAsync(pickCityId);
    //     var deliverCity = await _context.Cities.FindAsync(deliverCityId);

    //     if (pickCity == null || deliverCity == null) throw new Exception("Invalid city selected.");

    //     var pricing = await _context.Pricings.OrderByDescending(p => p.CreatedAt).FirstOrDefaultAsync();
    //     if (pricing == null) throw new Exception("Pricing details not available.");

    //     decimal basePrice = (decimal)(pricing.BasePrice ?? 0);
    //     decimal pricePerKm = (decimal)(pricing.PricePerKm ?? 0);

    //     var route = await _context.Deliveryroutes
    //         .FirstOrDefaultAsync(r => r.FromCityId == pickCityId && r.ToCityId == deliverCityId);

    //     if (route == null) throw new Exception("No delivery route found.");

    //     decimal estimatedPrice = (decimal)(basePrice + (pricePerKm * route.DistanceKm));

    //     if (parcelType == "medium") estimatedPrice *= 2;
    //     if (parcelType == "large") estimatedPrice *= 4;

    //     return estimatedPrice;
    // }

    public async Task<decimal> CalculateEstimateAsync(string pickCityName, string deliverCityName, string parcelType)
    {
        // Fetch pickup city by name
        var pickCity = await _context.Cities
            .FirstOrDefaultAsync(c => c.Name.ToLower() == pickCityName.ToLower());

        // Fetch delivery city by name
        var deliverCity = await _context.Cities
            .FirstOrDefaultAsync(c => c.Name.ToLower() == deliverCityName.ToLower());

        // Handle invalid city inputs
        if (pickCity == null) throw new Exception($"Pickup city '{pickCityName}' not found.");
        if (deliverCity == null) throw new Exception($"Delivery city '{deliverCityName}' not found.");

        // Fetch latest pricing details
        var pricing = await _context.Pricings.OrderByDescending(p => p.CreatedAt).FirstOrDefaultAsync();
        if (pricing == null) throw new Exception("Pricing details not available.");

        decimal basePrice = pricing.BasePrice ?? 0;
        decimal pricePerKm = pricing.PricePerKm ?? 0;

        // Find the delivery route based on city IDs
        var route = await _context.Deliveryroutes
            .FirstOrDefaultAsync(r => r.FromCityId == pickCity.Id && r.ToCityId == deliverCity.Id);

        if (route == null) throw new Exception($"No delivery route found between {pickCityName} and {deliverCityName}.");

        // Calculate base estimated price
        decimal estimatedPrice = (decimal)(basePrice + (pricePerKm * route.DistanceKm));

        // Handle parcel type in a case-insensitive manner
        switch (parcelType?.Trim().ToLower())
        {
            case "small":
                break; // No change for small parcels (base price)
            case "medium":
                estimatedPrice *= 2; // Medium parcels cost 2x the base price
                break;
            case "large":
                estimatedPrice *= 4; // Large parcels cost 4x the base price
                break;
            default:
                throw new Exception("Invalid parcel type provided.");
        }

        return estimatedPrice;
    }



}
