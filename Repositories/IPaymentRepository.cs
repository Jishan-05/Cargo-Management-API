using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Repositories
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Booking>> GetPendingPaymentsAsync();
        Task<bool> AcceptPaymentAsync(int bookingId, int userId);
    }
}
