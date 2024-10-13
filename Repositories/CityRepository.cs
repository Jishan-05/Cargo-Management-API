using CargoManagementSystem.Data;
using CargoManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _context;

        public CityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            return await _context.Cities
                                 .Include(c => c.State)
                                 .Include(c => c.DeliveryrouteFromCities)
                                 .Include(c => c.DeliveryrouteToCities)
                                 .Include(c => c.ParcelFromCities)
                                 .Include(c => c.ParcelToCities)
                                 .ToListAsync();
        }

        public async Task<City?> GetCityByIdAsync(int id)
        {
            return await _context.Cities
                                 .Include(c => c.State)
                                 .Include(c => c.DeliveryrouteFromCities)
                                 .Include(c => c.DeliveryrouteToCities)
                                 .Include(c => c.ParcelFromCities)
                                 .Include(c => c.ParcelToCities)
                                 .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<City> AddCityAsync(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<City> UpdateCityAsync(City city)
        {
            _context.Entry(city).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<bool> DeleteCityAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return false;
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
