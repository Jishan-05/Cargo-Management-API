using CargoManagementSystem.Data;
using CargoManagementSystem.Models;
using Microsoft.EntityFrameworkCore; 

public class DeliveryRouteRepository : IDeliveryRouteRepository
{
    private readonly AppDbContext _context;

    public DeliveryRouteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Deliveryroute>> GetAllAsync()
    {
        return await _context.Deliveryroutes
            .Include(dr => dr.FromCity)
            .Include(dr => dr.ToCity)
            .ToListAsync();
    }

    public async Task<Deliveryroute> GetByIdAsync(int id)
    {
        return await _context.Deliveryroutes
            .Include(dr => dr.FromCity)
            .Include(dr => dr.ToCity)
            .FirstOrDefaultAsync(dr => dr.Id == id);
    }

    public async Task AddAsync(Deliveryroute deliveryRoute)
    {
        await _context.Deliveryroutes.AddAsync(deliveryRoute);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Deliveryroute deliveryRoute)
    {
        _context.Deliveryroutes.Update(deliveryRoute);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var deliveryRoute = await _context.Deliveryroutes.FindAsync(id);
        if (deliveryRoute != null)
        {
            _context.Deliveryroutes.Remove(deliveryRoute);
            await _context.SaveChangesAsync();
        }
    }
}
