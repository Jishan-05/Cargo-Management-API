
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

    public async Task<Customer> CreateAsync(CreateCustomerDto customerDto)
    {
        var user = new User
        {
            Username = customerDto.Username,
            FirstName = customerDto.FirstName,
            LastName = customerDto.LastName,
            Email = customerDto.Email,
            Password = customerDto.Password, // Ensure you hash the password before saving
            Role = "Customer", // Default role for the user
            DateJoined = DateTime.Now
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        var customer = new Customer
        {
            UserId = user.Id,
            PhoneNumber = customerDto.PhoneNumber,
            Address = customerDto.Address
        };

        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();

        return customer;
    }

    public async Task<Customer> UpdateAsync(int id, UpdateCustomerDto customerDto)
    {
        var customer = await _context.Customers.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == id);

        if (customer == null)
        {
            return null;
        }

        customer.User.Username = customerDto.Username;
        customer.User.FirstName = customerDto.FirstName;
        customer.User.LastName = customerDto.LastName;
        customer.User.Email = customerDto.Email;
        customer.PhoneNumber = customerDto.PhoneNumber;
        customer.Address = customerDto.Address;

        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        return await _context.Customers.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers.Include(c => c.User).ToListAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var customer = await _context.Customers.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == id);

        if (customer == null)
        {
            return false;
        }

        _context.Customers.Remove(customer);

        if (customer.User != null)
        {
            _context.Users.Remove(customer.User); // Delete related user
        }

        await _context.SaveChangesAsync();
        return true;
    }


    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        return await _context.Customers
            .Include(c => c.User)  // Include related User if needed
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}
