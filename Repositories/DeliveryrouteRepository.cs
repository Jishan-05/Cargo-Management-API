using CargoManagementSystem.Data;
using CargoManagementSystem.Models;
using CargoManagementSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Repositories
{
    public class DeliveryrouteRepository : IDeliveryrouteRepository
    {
        private readonly AppDbContext _context;

        public DeliveryrouteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Deliveryroute>> GetAllDeliveryroutesAsync()
        {
            return await _context.Deliveryroutes
                                 .Include(dr => dr.FromCity)
                                 .Include(dr => dr.ToCity)
                                 .ToListAsync();
        }

        public async Task<Deliveryroute?> GetDeliveryrouteByIdAsync(int id)
        {
            return await _context.Deliveryroutes
                                 .Include(dr => dr.FromCity)
                                 .Include(dr => dr.ToCity)
                                 .FirstOrDefaultAsync(dr => dr.Id == id);
        }

        public async Task<Deliveryroute> AddDeliveryrouteAsync(Deliveryroute deliveryroute)
        {
            _context.Deliveryroutes.Add(deliveryroute);
            await _context.SaveChangesAsync();
            return deliveryroute;
        }

        public async Task<Deliveryroute> UpdateDeliveryrouteAsync(Deliveryroute deliveryroute)
        {
            _context.Entry(deliveryroute).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return deliveryroute;
        }

        public async Task<bool> DeleteDeliveryrouteAsync(int id)
        {
            var deliveryroute = await _context.Deliveryroutes.FindAsync(id);
            if (deliveryroute == null)
            {
                return false;
            }

            _context.Deliveryroutes.Remove(deliveryroute);
            await _context.SaveChangesAsync();
            return true;
        }
    }

    public interface IDeliveryrouteRepository
    {
        Task<IEnumerable<Deliveryroute>> GetAllDeliveryroutesAsync();
        Task<Deliveryroute?> GetDeliveryrouteByIdAsync(int id);
        Task<Deliveryroute> AddDeliveryrouteAsync(Deliveryroute deliveryroute);
        Task<Deliveryroute> UpdateDeliveryrouteAsync(Deliveryroute deliveryroute);
        Task<bool> DeleteDeliveryrouteAsync(int id);
    }
}
