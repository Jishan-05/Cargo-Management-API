using CargoManagementSystem.DTOs;
using CargoManagementSystem.Data;
using CargoManagementSystem.Repositories;
using CargoManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    
    private readonly IBookingService _bookingService;
    private readonly ParcelService _parcelService;

    private readonly IUserRepository  _userRepository;


    public DashboardController(IBookingService bookingService, IUserRepository userRepository, ParcelService parcelService)
    {
        _bookingService = bookingService; 
        _userRepository = userRepository;
        _parcelService = parcelService;
    }

    [HttpGet("overview")]
    public async Task<IActionResult> GetDashboardOverview()
    {
        
        var totalUsers = await _userRepository.GetTotalUsersAsync();
        var totalCustomers = await _userRepository.GetTotalCustomersAsync();
        var totalEmployees = await _userRepository.GetTotalEmployeesAsync();
        var totalBookings = await _bookingService.GetBookingsAsync();
        var totalParcels = await _parcelService.GetAllParcelsAsync();

        var dashboardData = new
        {
            
            TotalUsers = totalUsers,
            TotalCustomers = totalCustomers,
            TotalEmployees = totalEmployees,
            TotalBookingCount = totalBookings.Count(),
            PendingPaymentCount = totalBookings.Where(b => b.PaymentStatus == "Pending").Count(),
            DeliveredBookingCount = totalParcels.Where(p => p.Status == "Delivered").Count(),
            InTransitBookingCount = totalParcels.Where(p => p.Status == "In Transit").Count(),
            ArrivedBookingCount = totalParcels.Where(p => p.Status == "Arrived").Count()
        };

        return Ok(dashboardData);
    }
}
