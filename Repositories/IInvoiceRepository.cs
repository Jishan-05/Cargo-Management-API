using CargoManagementSystem.Models;

namespace CargoManagementSystem.Repositories
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAllInvoicesAsync();
        Task<Invoice> GetInvoiceByIdAsync(int id);
        Task AddInvoiceAsync(Invoice invoice);
        
    }
    
}
