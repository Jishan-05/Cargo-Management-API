// AdminRepository.cs
using CargoManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

public class AdminRepository : IAdminRepository
{
    private readonly AppDbContext _context;

    public AdminRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<AdminDto>> GetAdminListAsync()
    {
        var adminList = await _context.Admins
            .Include(a => a.User) // Join with the User table
            .Select(a => new AdminDto
            {
                Id = a.Id,
                Username = a.User.Username,
                AdminName = a.User.FirstName + " " + a.User.LastName,
                Contact = a.PhoneNumber,
                Email = a.User.Email,
                Address = a.Address
            })
            .ToListAsync();

        return adminList;
    }
}
