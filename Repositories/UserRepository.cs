using CargoManagementSystem.Data;
using CargoManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Repositories
{
 
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> GetTotalUsersAsync()
    {
        // Assuming 'role' column differentiates users
        return await _context.Users.CountAsync(u => u.Role != "Admin");
    }

    public async Task<int> GetTotalCustomersAsync()
    {
        return await _context.Users.CountAsync(u => u.Role == "Customer");
    }

    public async Task<int> GetTotalEmployeesAsync()
    {
        return await _context.Users.CountAsync(u => u.Role == "Employee");
    }
}
   
}