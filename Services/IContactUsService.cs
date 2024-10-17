using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CargoManagementSystem.Services
{
    public interface IContactUsService
    {
        Task AddContactUsAsync(Contactus contactUs);
        Task<IEnumerable<Contactus>> GetAllContactUsAsync();
        Task<Contactus> GetContactUsByIdAsync(int id);
        Task UpdateContactUsAsync(int id, Contactus contactUs);
        Task DeleteContactUsAsync(int id);
    }
}
