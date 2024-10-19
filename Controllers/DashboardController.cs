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

    private readonly IUserRepository  _userRepository;


    public DashboardController(IBookingService bookingService, IUserRepository userRepository)
    {
        _bookingService = bookingService;
        _userRepository = userRepository;
    }

    [HttpGet("overview")]
    public async Task<IActionResult> GetDashboardOverview()
    {
        
        var totalUsers = await _userRepository.GetTotalUsersAsync();
        var totalCustomers = await _userRepository.GetTotalCustomersAsync();
        var totalEmployees = await _userRepository.GetTotalEmployeesAsync();

        var dashboardData = new
        {
            
            TotalUsers = totalUsers,
            TotalCustomers = totalCustomers,
            TotalEmployees = totalEmployees
        };

        return Ok(dashboardData);
    }
}
