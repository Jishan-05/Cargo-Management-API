using CargoManagementSystem.Data;
using CargoManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

public class ParcelRepository : IParcelRepository
{
    private readonly AppDbContext _context;

    public ParcelRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Parcel> GetParcelByIdAsync(int id)
{
    var parcel = await _context.Parcels.FirstOrDefaultAsync(p => p.Id == id);
    return parcel;  // This returns a single Parcel
}



    // Other methods
}
