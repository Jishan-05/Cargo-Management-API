using CargoManagementSystem.Models;
using CargoManagementSystem.Extensions;
using CargoManagementSystem.Repositories;
using CargoManagementSystem.DTOs;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using System.IO;
using System.Threading.Tasks;
// Import your extension method

namespace CargoManagementSystem.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IBookingRepository _bookingRepository;


        public InvoiceService(IInvoiceRepository invoiceRepository,IBookingRepository bookingRepository)
        {
            _invoiceRepository = invoiceRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<string> GenerateInvoiceAsync(int bookingId)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(bookingId);
            
            if (booking == null)
            {
                return null; // Handle not found
            }

            // Check if an invoice already exists for this booking
            var existingInvoice = await _invoiceRepository.GetInvoiceByIdAsync(bookingId);
            if (existingInvoice != null)
            {
                return "Invoice already exists for this booking."; // Validation message
            }

            // Create a new invoice since it doesn't exist
            var invoice = new Invoice
            {
                CustmerName = $"{booking.Customer.User.FirstName} {booking.Customer.User.LastName}",
                Description = $"{booking.Parcel.FromCity.Name} to {booking.Parcel.ToCity.Name}",
                Price = booking.Parcel.Price.HasValue ? booking.Parcel.Price.Value.ToString("F2") : "0.00",
                CreatedOn = DateOnly.FromDateTime(DateTime.Now),
                BookingId = booking.Id
            };

            await _invoiceRepository.AddInvoiceAsync(invoice);

            var htmlContent = $@"
                <div class=""container"">
                    <div class=""header"">
                        <h1>Shubh Laxmi Cargo Movers</h1>
                        <h1>Invoice</h1>
                    </div>
                    <div class=""invoice-info"">
                        <table>
                            <tr>
                                <th>Invoice Number:</th>
                                <td>INV-{invoice.Id}</td>
                            </tr>
                            <tr>
                                <th>Invoice Date:</th>
                                <td>{invoice.CreatedOn}</td>
                            </tr>
                        </table>
                    </div>
                    <div class=""customer-info"">
                        <h2>Customer Information</h2>
                        <table>
                            <tr>
                                <th>Customer Name:</th>
                                <td>{invoice.CustmerName}</td>
                            </tr>
                            <tr>
                                <th>Address:</th>
                                <td>{booking.Customer.Address}</td>
                            </tr>
                            <tr>
                                <th>Email:</th>
                                <td>{booking.Customer.User.Email}</td>
                            </tr>
                            <tr>
                                <th>Phone:</th>
                                <td>{booking.Customer.PhoneNumber}</td>
                            </tr>
                        </table>
                    </div>
                    <div class=""item-list"">
                        <h2>Invoice Items</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>Description</th>
                                    <th>Total</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>{invoice.Description}</td>
                                    <td>&#8377; {invoice.Price}</td>
                                </tr>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <td colspan=""1"" class=""total"">Total:</td>
                                    <td>&#8377; {invoice.Price}</td>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>";

            return htmlContent; // Return the generated HTML invoice
        }

        


        public async Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync()
        {
            var invoices = await _invoiceRepository.GetAllInvoicesAsync();
            return invoices.Select(invoice => new InvoiceDto
            {
                Id = invoice.Id,
                CustomerName = invoice.CustmerName, // Fixed typo here
                Description = invoice.Description,
                Price = invoice.Price, // Ensure Price is decimal
                CreatedOn = invoice.CreatedOn.ToDateTime(TimeOnly.MinValue), // Convert DateOnly to DateTime
                BookingId = invoice.BookingId,
                Booking = new BookingListDto // Mapping Booking to DTO
                {
                    // Fill booking details here
                }
            });
        }

        public async Task<InvoiceDto> GetInvoiceByIdAsync(int id)
        {
            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id);
            if (invoice == null)
            {
                return null; // Handle not found
            }

            return new InvoiceDto
            {
                Id = invoice.Id,
                CustomerName = invoice.CustmerName, // Fixed typo here
                Description = invoice.Description,
                Price = invoice.Price, // Ensure Price is decimal
                CreatedOn = invoice.CreatedOn.ToDateTime(TimeOnly.MinValue), // Convert DateOnly to DateTime
                BookingId = invoice.BookingId,
                Booking = new BookingListDto() // Mapping Booking to DTO
            };
        }

        

       
    }
}
