using System.Linq;  // Ensure to include this for .Select() LINQ
using CargoManagementSystem.Models;
using CargoManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("pending-payments")]
        public async Task<IActionResult> GetPendingPayments()
        {
            var pendingPayments = await _paymentService.GetPendingPaymentsAsync();
            return Ok(pendingPayments);
        }

        

        [HttpPost("accept-payment/{id}")]
        public async Task<IActionResult> AcceptPayment(int id, int userId)
        {
            var result = await _paymentService.AcceptPaymentAsync(id, userId);
            if (result)
            {
                return Ok(new { Message = "Payment accepted!" });
            }

            return NotFound(new { Message = "Booking not found!" });
        }
    }
}
