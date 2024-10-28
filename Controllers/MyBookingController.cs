using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MyBookingController : ControllerBase
{
    private readonly IBookingService _bookingService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public MyBookingController(IBookingService bookingService, IHttpContextAccessor httpContextAccessor)
    {
        _bookingService = bookingService;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet("my-bookings")]
    public async Task<IActionResult> GetMyBookings()
    {
        // Get the customer ID from the JWT token claims
        var customerIdClaim = _httpContextAccessor.HttpContext.User.Claims
            .FirstOrDefault(c => c.Type == "CustomerId");
        if (customerIdClaim == null)
        {
            return Unauthorized("Customer ID not found in token.");
        }

        if (!int.TryParse(customerIdClaim.Value, out var customerId))
        {
            return Unauthorized("Invalid Customer ID.");
        }

        // Retrieve bookings for the customer
        var bookings = await _bookingService.GetCustomerBookingsAsync(customerId);

        return Ok(bookings);
    }
}

