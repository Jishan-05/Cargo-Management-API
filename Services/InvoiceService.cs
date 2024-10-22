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

    // Plain text output
    var Invoice = $@"
    Invoice Number: INV-{invoice.Id}
    Invoice Date: {invoice.CreatedOn}
    
    Customer Information:
    Name: {invoice.CustmerName}
    Address: {booking.Customer.Address}
    Email: {booking.Customer.User.Email}
    Phone: {booking.Customer.PhoneNumber}
    
    Booking Details:
    From: {booking.Parcel.FromCity.Name}
    To: {booking.Parcel.ToCity.Name}
    
    Description: {invoice.Description}
    Price: Rs. {invoice.Price}

    Total: Rs.{invoice.Price}
    ";

    return Invoice; // Return the plain text invoice
}
        
public async Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync()
{
    var invoices = await _invoiceRepository.GetAllInvoicesAsync();
    var invoiceDtos = new List<InvoiceDto>();

    foreach (var invoice in invoices)
    {
        var booking = await _bookingRepository.GetBookingByIdAsync(invoice.BookingId);

        // Build the plain text invoice
        var Invoice = $@"
        Invoice Number: INV-{invoice.Id}
        Invoice Date: {invoice.CreatedOn.ToDateTime(TimeOnly.MinValue):MM/dd/yyyy}
        
        Customer Information:
        Name: {invoice.CustmerName}
        Address: {booking.Customer.Address}
        Email: {booking.Customer.User.Email}
        Phone: {booking.Customer.PhoneNumber}
        
        Booking Details:
        From: {booking.Parcel.FromCity.Name}
        To: {booking.Parcel.ToCity.Name}
        
        Description: {invoice.Description}
        Price: Rs. {invoice.Price}

        Total: Rs.{invoice.Price}
        ";

        // Create the InvoiceDto object
        invoiceDtos.Add(new InvoiceDto
        {
            Id = invoice.Id,
            CustomerName = invoice.CustmerName,
            Description = invoice.Description,
            Price = invoice.Price,
            CreatedOn = invoice.CreatedOn.ToDateTime(TimeOnly.MinValue),
            BookingId = invoice.BookingId,
            Invoice = Invoice
        });
    }

    return invoiceDtos;
}

 public async Task<InvoiceDto> GetInvoiceByIdAsync(int id)
{
    var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id);
    
    if (invoice == null)
    {
        return null; // Handle not found
    }

    var booking = await _bookingRepository.GetBookingByIdAsync(invoice.BookingId);

    // Build the plain text invoice
    var Invoice = $@"
    Invoice Number: INV-{invoice.Id}
    Invoice Date: {invoice.CreatedOn.ToDateTime(TimeOnly.MinValue):MM/dd/yyyy}
    
    Customer Information:
    Name: {invoice.CustmerName}
    Address: {booking.Customer.Address}
    Email: {booking.Customer.User.Email}
    Phone: {booking.Customer.PhoneNumber}
    
    Booking Details:
    From: {booking.Parcel.FromCity.Name}
    To: {booking.Parcel.ToCity.Name}
    
    Description: {invoice.Description}
    Price: Rs. {invoice.Price}

    Total: Rs.{invoice.Price}
    ";

    return new InvoiceDto
    {
        Id = invoice.Id,
        CustomerName = invoice.CustmerName,
        Description = invoice.Description,
        Price = invoice.Price,
        CreatedOn = invoice.CreatedOn.ToDateTime(TimeOnly.MinValue),
        BookingId = invoice.BookingId,
        Invoice = Invoice // Set the plain text invoice
    };
}
 

       
    }
}
