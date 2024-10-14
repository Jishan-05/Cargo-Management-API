using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Repositories
{
    public interface IPricingRepository
    {
        Task<List<Pricing>> GetAllPricingAsync();
        Task<Pricing> GetPricingByIdAsync(int id);
        Task CreatePricingAsync(Pricing pricing);
        Task UpdatePricingAsync(Pricing pricing);
        Task DeletePricingAsync(int id);
    }
}
