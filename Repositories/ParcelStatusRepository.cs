using CargoManagementSystem.Data;
using CargoManagementSystem.Models;
using CargoManagementSystem.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Repositories
{
   public class ParcelStatusRepository : IParcelStatusRepository
{
    private readonly AppDbContext _context; // Replace DbContext with your actual DbContext class

    public ParcelStatusRepository(AppDbContext context)
    {
        _context = context;
    }

     public async Task<IEnumerable<ParcelStatusDto>> GetParcelStatusesByParcelIdAsync(int parcelId)
    {
        return await _context.Parcelstatuses
            .Where(ps => ps.ParcelId == parcelId) // Fetch multiple statuses for the same parcel
            .Select(ps => new ParcelStatusDto
            {
                Status = ps.Status,
                UpdatedAt = ps.UpdatedAt.HasValue ? ps.UpdatedAt.Value : DateTime.MinValue
            })
            .OrderByDescending(ps => ps.UpdatedAt) // Optional: Sort by most recent status
            .ToListAsync();
    }
} 
}

