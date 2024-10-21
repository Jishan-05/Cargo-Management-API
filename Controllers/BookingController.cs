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

    [HttpPost("{id}/update-status")]
    public async Task<IActionResult> UpdateBookingStatus(int id, [FromBody] UpdateStatusDto statusDto)
    {
        try
        {
            // Assuming user ID is passed in the request (from session, JWT, etc.)
            int userId = 3; // Replace with the actual logged-in user ID
            await _bookingService.UpdateBookingStatusAsync(id, statusDto.Status, userId);
            return Ok(new { message = "Status updated successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet("estimate")]
    public async Task<IActionResult> GetEstimate(string pickCityName, string deliverCityName, string parcelType)
    {
        var estimate = await _bookingService.CalculateEstimateAsync(pickCityName,deliverCityName,parcelType);
        return Ok(new { EstimatedPrice = estimate });
    }
}
