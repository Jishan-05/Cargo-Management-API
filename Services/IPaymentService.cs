using CargoManagementSystem.DTOs;
namespace CargoManagementSystem.Services
{
 
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetPendingPaymentsAsync();
        Task<bool> AcceptPaymentAsync(int bookingId, int userId);
    }
   
}