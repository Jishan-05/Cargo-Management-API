using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Repositories
{
    public interface IContactusRepository
    {
        Task<IEnumerable<Contactus>> GetAllAsync();
        Task<Contactus> GetByIdAsync(int id);
        Task CreateAsync(Contactus contactUs);
        Task UpdateAsync(Contactus contactUs);
        Task DeleteAsync(int id);
    }
}
