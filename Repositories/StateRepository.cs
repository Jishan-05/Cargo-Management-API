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

        public async Task<IEnumerable<State>> GetAllStatesAsync()
        {
            return await _context.States
                                 .Include(s => s.Cities)
                                 .Include(s => s.Country)
                                 .ToListAsync();
        }

        public async Task<State?> GetStateByIdAsync(int id)
        {
            return await _context.States
                                 .Include(s => s.Cities)
                                 .Include(s => s.Country)
                                 .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<State> AddStateAsync(State state)
        {
            _context.States.Add(state);
            await _context.SaveChangesAsync();
            return state;
        }

        public async Task<State> UpdateStateAsync(State state)
        {
            _context.Entry(state).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return state;
        }

        public async Task<bool> DeleteStateAsync(int id)
        {
            var state = await _context.States.FindAsync(id);
            if (state == null)
            {
                return false;
            }

            _context.States.Remove(state);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
