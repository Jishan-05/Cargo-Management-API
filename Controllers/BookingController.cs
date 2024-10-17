using CargoManagementSystem.DTOs;
using CargoManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetBookings()
    {
        var bookings = await _bookingService.GetBookingsAsync();
        return Ok(bookings);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddBooking([FromBody] AddBookingDto addBookingDto)
    {
        try
        {
            var booking = await _bookingService.AddBookingAsync(addBookingDto);

            // Return booking details along with city names
            return Ok(new 
            {
                booking,
                PickupCity = addBookingDto.PickCityName,
                DeliverCity = addBookingDto.DeliverCityName
            });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("estimate")]
    public async Task<IActionResult> GetEstimate(string pickCityName, string deliverCityName, string parcelType)
    {
        var estimate = await _bookingService.CalculateEstimateAsync(pickCityName,deliverCityName,parcelType);
        return Ok(new { EstimatedPrice = estimate });
    }
}
