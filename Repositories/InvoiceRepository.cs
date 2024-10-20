using CargoManagementSystem.Data;
using CargoManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CargoManagementSystem.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _context;

        public InvoiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
        {
            return await _context.Invoices.Include(i => i.Booking).ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            return await _context.Invoices.Include(i => i.Booking).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddInvoiceAsync(Invoice invoice)
        {
            await _context.Invoices.AddAsync(invoice);
            await _context.SaveChangesAsync();
        }

        
    }

}
