using CargoManagementSystem.Data;
using CargoManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await _context.Customers
            .Include(c => c.User)
            .Select(c => new Customer
            {
                Id = c.Id,
                UserId = c.UserId,
                PhoneNumber = c.PhoneNumber,
                Address = c.Address,
                User = new User
                {
                    Id = c.User.Id,
                    Username = c.User.Username,
                    Password = c.User.Password,
                    Email = c.User.Email,
                    FirstName = c.User.FirstName,
                    LastName = c.User.LastName,
                    Role = c.User.Role,
                    DateJoined = c.User.DateJoined
                }
            })
            .ToListAsync();
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        return await _context.Customers
            .Include(c => c.User)
            .Where(c => c.Id == id)
            .Select(c => new Customer
            {
                Id = c.Id,
                UserId = c.UserId,
                PhoneNumber = c.PhoneNumber,
                Address = c.Address,
                User = new User
                {
                    Id = c.User.Id,
                    Username = c.User.Username,
                    Password = c.User.Password,
                    Email = c.User.Email,
                    FirstName = c.User.FirstName,
                    LastName = c.User.LastName,
                    Role = c.User.Role,
                    DateJoined = c.User.DateJoined
                }
            })
            .FirstOrDefaultAsync();
    }

    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        // Add User first
        _context.Users.Add(customer.User);

        // Add Customer
        _context.Customers.Add(customer);

        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        // Update User
        _context.Entry(customer.User).State = EntityState.Modified;

        // Update Customer
        _context.Entry(customer).State = EntityState.Modified;
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCustomerAsync(int id)
    {
        var customer = await _context.Customers.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == id);
        
        if (customer != null)
        {
            // Delete User
            _context.Users.Remove(customer.User);

            // Then delete Customer
            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();
        }
    }
}
