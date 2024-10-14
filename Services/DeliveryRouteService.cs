using CargoManagementSystem.Data;
using CargoManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DeliveryRouteService
{
    private readonly IDeliveryRouteRepository _repository;
    private readonly AppDbContext _context;

    public DeliveryRouteService(IDeliveryRouteRepository repository, AppDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task<List<Deliveryroute>> GetAllRoutesAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Deliveryroute> GetRouteByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task CreateRouteAsync(CreateDeliveryRouteDto createDto)
    {
        var fromCity = await _context.Cities.FirstOrDefaultAsync(c => c.Name == createDto.FromCityName);
        var toCity = await _context.Cities.FirstOrDefaultAsync(c => c.Name == createDto.ToCityName);

        if (fromCity == null || toCity == null)
        {
            throw new InvalidOperationException("One or both cities not found.");
        }

        var deliveryRoute = new Deliveryroute
        {
            FromCityId = fromCity.Id,
            ToCityId = toCity.Id,
            DistanceKm = createDto.DistanceKm
        };

        await _repository.AddAsync(deliveryRoute);
    }

    public async Task UpdateRouteAsync(int id, UpdateDeliveryRouteDto updateDto)
    {
        var deliveryRoute = await _repository.GetByIdAsync(id);
        if (deliveryRoute == null)
        {
            throw new KeyNotFoundException("Delivery route not found.");
        }

        var fromCity = await _context.Cities.FirstOrDefaultAsync(c => c.Name == updateDto.FromCityName);
        var toCity = await _context.Cities.FirstOrDefaultAsync(c => c.Name == updateDto.ToCityName);

        if (fromCity == null || toCity == null)
        {
            throw new InvalidOperationException("One or both cities not found.");
        }

        deliveryRoute.FromCityId = fromCity.Id;
        deliveryRoute.ToCityId = toCity.Id;
        deliveryRoute.DistanceKm = updateDto.DistanceKm;

        await _repository.UpdateAsync(deliveryRoute);
    }

    public async Task DeleteRouteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
