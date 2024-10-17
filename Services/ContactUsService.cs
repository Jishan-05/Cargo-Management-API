using CargoManagementSystem.DTOs;
using CargoManagementSystem.Models;
using CargoManagementSystem.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoManagementSystem.Services
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository _contactUsRepository;

        public ContactUsService(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        public async Task AddContactUsAsync(Contactus contactUs)
        {
            if (contactUs == null)
            {
                throw new ArgumentNullException(nameof(contactUs));
            }

            await _contactUsRepository.AddContactUs(contactUs);
        }

        public async Task<IEnumerable<Contactus>> GetAllContactUsAsync()
        {
            return await _contactUsRepository.GetAllContactUsAsync();
        }

        public async Task<Contactus> GetContactUsByIdAsync(int id)
        {
            return await _contactUsRepository.GetContactUsByIdAsync(id);
        }

        public async Task UpdateContactUsAsync(int id, Contactus contactUs)
        {
            if (contactUs == null)
            {
                throw new ArgumentNullException(nameof(contactUs));
            }

            await _contactUsRepository.UpdateContactUsAsync(id, contactUs);
        }

        public async Task DeleteContactUsAsync(int id)
        {
            await _contactUsRepository.DeleteContactUsAsync(id);
        }
    }
}
