using CargoManagementSystem.DTOs;
using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CargoManagementSystem.Services
{
    public interface IInvoiceService
    {
        Task<string> GenerateInvoiceAsync(int bookingId);
        Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync();
        Task<InvoiceDto> GetInvoiceByIdAsync(int id);
        
    }
    
}
