using CargoManagementSystem.Models;
using CargoManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Repositories
{
    public class ContactusRepository : IContactusRepository
    {
        private readonly AppDbContext _context;

        public ContactusRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contactus>> GetAllAsync() => await _context.Contactus.ToListAsync();

        public async Task<Contactus> GetByIdAsync(int id) => await _context.Contactus.FirstOrDefaultAsync(c => c.Id == id);

        public async Task CreateAsync(Contactus contactUs)
        {
            if (contactUs == null) throw new ArgumentNullException(nameof(contactUs));
            _context.Contactus.Add(contactUs);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Contactus contactUs)
        {
            if (contactUs == null) throw new ArgumentNullException(nameof(contactUs));
            _context.Contactus.Update(contactUs);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contactUs = await GetByIdAsync(id);
            if (contactUs == null) throw new KeyNotFoundException("Contact not found.");
            _context.Contactus.Remove(contactUs);
            await _context.SaveChangesAsync();
        }
    }
}
