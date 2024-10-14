using CargoManagementSystem.Data;
using CargoManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<City>> GetCitiesAsync()
        {
            return await _context.Cities
                .Include(c => c.State)
                .ThenInclude(s => s.Country)
                .ToListAsync();
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            return await _context.Cities
                .Include(c => c.State)
                .ThenInclude(s => s.Country)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<State> GetStateByNameAsync(string stateName)
        {
            return await _context.States
                .Include(s => s.Country)
                .FirstOrDefaultAsync(s => s.Name == stateName);
        }

        public async Task<bool> CityExistsInStateAsync(string cityName, int stateId)
        {
            return await _context.Cities.AnyAsync(c => c.Name == cityName && c.StateId == stateId);
        }

        public async Task AddCityAsync(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCityAsync(City city)
        {
            _context.Cities.Update(city);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCityAsync(City city)
        {
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CityExistsAsync(int id)
        {
            return await _context.Cities.AnyAsync(c => c.Id == id);
        }

        public async Task<City?> GetCityByNameAsync(string cityName)
        {
            return await _context.Cities.FirstOrDefaultAsync(c => c.Name == cityName);
        }

    }
}
