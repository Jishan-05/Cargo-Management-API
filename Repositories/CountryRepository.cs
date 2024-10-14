using CargoManagementSystem.Data;
using CargoManagementSystem.DTOs;
using CargoManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoManagementSystem.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _context;

        public CountryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CountryDto>> GetCountriesAsync()
        {
            return await _context.Countries
                .Select(c => new CountryDto { Name = c.Name })
                .ToListAsync();
        }

        public async Task<Country> GetCountryByIdAsync(int id)
        {
            return await _context.Countries.FindAsync(id);
        }

        public async Task<Country> GetCountryByNameAsync(string name)
        {
            return await _context.Countries
                .FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task AddCountryAsync(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCountryAsync(Country country)
        {
            _context.Countries.Update(country);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCountryAsync(Country country)
        {
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CountryExistsByNameAsync(string name)
        {
            return await _context.Countries.AnyAsync(c => c.Name == name);
        }

        public async Task<bool> CountryExistsByIdAsync(int id)
        {
            return await _context.Countries.AnyAsync(c => c.Id == id);
        }
    }
}
