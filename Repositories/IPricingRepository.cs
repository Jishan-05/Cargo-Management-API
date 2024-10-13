using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Repositories
{
    public interface IPricingRepository
    {
        Task<IEnumerable<Pricing>> GetAllPricingsAsync();
        Task<Pricing?> GetPricingByIdAsync(int id);
        Task<Pricing> AddPricingAsync(Pricing pricing);
        Task<Pricing> UpdatePricingAsync(Pricing pricing);
        Task<bool> DeletePricingAsync(int id);
    }
}
