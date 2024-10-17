using CargoManagementSystem.Data;
using CargoManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoManagementSystem.Repositories
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly AppDbContext _context;

        public ContactUsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddContactUs(Contactus contactUs)
        {
            _context.Contactus.Add(contactUs);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contactus>> GetAllContactUsAsync()
        {
            return await _context.Contactus.ToListAsync();
        }

        public async Task<Contactus> GetContactUsByIdAsync(int id)
        {
            return await _context.Contactus.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateContactUsAsync(int id, Contactus contactUs)
        {
            var existingContactUs = await _context.Contactus.FirstOrDefaultAsync(c => c.Id == id);

            if (existingContactUs == null)
            {
                throw new KeyNotFoundException("Contact Us entry not found");
            }

            existingContactUs.Name = contactUs.Name;
            existingContactUs.Email = contactUs.Email;
            existingContactUs.PhoneNumber = contactUs.PhoneNumber;
            existingContactUs.Message = contactUs.Message;

            _context.Contactus.Update(existingContactUs);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContactUsAsync(int id)
        {
            var contactUs = await _context.Contactus.FirstOrDefaultAsync(c => c.Id == id);

            if (contactUs == null)
            {
                throw new KeyNotFoundException("Contact Us entry not found");
            }

            _context.Contactus.Remove(contactUs);
            await _context.SaveChangesAsync();
        }
    }
}
