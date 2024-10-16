using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Repositories
{
    public interface IContactUsRepository
    {
        Task AddContactUs(Contactus contactUs);
        Task<IEnumerable<Contactus>> GetAllContactUsAsync();
        Task<Contactus> GetContactUsByIdAsync(int id);
        Task UpdateContactUsAsync(int id, Contactus contactUs);
        Task DeleteContactUsAsync(int id);
    }
}
