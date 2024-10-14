using CargoManagementSystem.Data;
using CargoManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Repositories
{
    public class PricingRepository : IPricingRepository
    {
        private readonly AppDbContext _context;

        public PricingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pricing>> GetAllPricingAsync()
        {
            return await _context.Pricings.ToListAsync();
        }

        public async Task<Pricing> GetPricingByIdAsync(int id)
        {
            return await _context.Pricings.FindAsync(id);
        }

        public async Task CreatePricingAsync(Pricing pricing)
        {
            _context.Pricings.Add(pricing);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePricingAsync(Pricing pricing)
        {
            _context.Pricings.Update(pricing);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePricingAsync(int id)
        {
            var pricing = await _context.Pricings.FindAsync(id);
            if (pricing != null)
            {
                _context.Pricings.Remove(pricing);
                await _context.SaveChangesAsync();
            }
        }
    }
}
