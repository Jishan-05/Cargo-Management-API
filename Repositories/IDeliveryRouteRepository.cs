using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDeliveryRouteRepository
{
    Task<List<Deliveryroute>> GetAllAsync();
    Task<Deliveryroute> GetByIdAsync(int id);
    Task AddAsync(Deliveryroute deliveryRoute);
    Task UpdateAsync(Deliveryroute deliveryRoute);
    Task DeleteAsync(int id);
}
