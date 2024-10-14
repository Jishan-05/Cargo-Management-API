using CargoManagementSystem.Data;
using CargoManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext _context;

        public StateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<State>> GetStatesAsync()
        {
            return await _context.States.Include(s => s.Country).ToListAsync();
        }

        public async Task<State> GetStateByIdAsync(int id)
        {
            return await _context.States.Include(s => s.Country).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddStateAsync(State state)
        {
            _context.States.Add(state);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStateAsync(State state)
        {
            _context.States.Update(state);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStateAsync(State state)
        {
            _context.States.Remove(state);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> StateExistsInCountryAsync(string stateName, int countryId)
        {
            return await _context.States.AnyAsync(s => s.Name == stateName && s.CountryId == countryId);
        }

        public async Task<Country> GetCountryByNameAsync(string countryName)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Name == countryName);
        }
    }
}
