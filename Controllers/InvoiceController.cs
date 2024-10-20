using CargoManagementSystem.DTOs;
using CargoManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("generate/{bookingId}")]
        public async Task<IActionResult> GenerateInvoice(int bookingId)
        {
            var htmlContent = await _invoiceService.GenerateInvoiceAsync(bookingId);

            if (htmlContent == null)
            {
                return NotFound("Booking not found.");
            }

            return Content(htmlContent, "text/html"); // Return HTML content with the correct content type
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var invoices = await _invoiceService.GetAllInvoicesAsync();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
            if (invoice == null) return NotFound();
            return Ok(invoice);
        }

        
    }

}