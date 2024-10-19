using CargoManagementSystem.Data;
using CargoManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ParcelRepository : IParcelRepository
{
    private readonly AppDbContext _context;

    public ParcelRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Parcel>> GetAllParcelsAsync()
    {
        return await _context.Parcels
            .Include(p => p.Customer)     // Include Customer
            .ThenInclude(c => c.User)     // Include User data (first name, last name)
            .ToListAsync();
    }

    public async Task<Parcel> GetParcelByIdAsync(int id)
    {
        return await _context.Parcels
            .Include(p => p.Customer)     // Include Customer
            .ThenInclude(c => c.User)     // Include User data
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}
