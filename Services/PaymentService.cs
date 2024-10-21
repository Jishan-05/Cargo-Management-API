using System.Collections.Generic;
using System.Threading.Tasks;
using CargoManagementSystem.DTOs;
using CargoManagementSystem.Repositories;
namespace CargoManagementSystem.Services
{
 
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<PaymentDto>> GetPendingPaymentsAsync()
        {
            var bookings = await _paymentRepository.GetPendingPaymentsAsync();
            
            return bookings.Select(b => new PaymentDto
            {
                BookingId = b.Id,
                TrackingId = b.Parcel?.TrackingId ?? string.Empty,
                PaymentStatus = b.PaymentStatus,
                ParcelType = b.Parcel?.ParcelType ?? string.Empty,
                Price = b.Parcel?.Price ?? 0,
                CustomerName = $"{b.Customer?.User?.FirstName} {b.Customer?.User?.LastName}"
            }).ToList();
        }

        public async Task<bool> AcceptPaymentAsync(int bookingId, int userId)
    {
        return await _paymentRepository.AcceptPaymentAsync(bookingId, userId);
    }

        
    }
   
}