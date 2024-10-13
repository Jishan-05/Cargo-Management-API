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

        public async Task<IEnumerable<Pricing>> GetAllPricingsAsync()
        {
            return await _context.Pricings.ToListAsync();
        }

        public async Task<Pricing?> GetPricingByIdAsync(int id)
        {
            return await _context.Pricings.FindAsync(id);
        }

        public async Task<Pricing> AddPricingAsync(Pricing pricing)
        {
            // Ensure that the ID is not being manually set by setting it to default value
            pricing.Id = 0; // You can remove this line if the ID is not being passed at all in the request

            _context.Pricings.Add(pricing);
            await _context.SaveChangesAsync();
            return pricing;
        }


        public async Task<Pricing> UpdatePricingAsync(Pricing pricing)
        {
            _context.Entry(pricing).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return pricing;
        }

        public async Task<bool> DeletePricingAsync(int id)
        {
            var pricing = await _context.Pricings.FindAsync(id);
            if (pricing == null)
            {
                return false;
            }

            _context.Pricings.Remove(pricing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
