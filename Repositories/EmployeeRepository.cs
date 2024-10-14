using CargoManagementSystem.Data;
using CargoManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Employee> CreateAsync(CreateEmployeeDto employeeDto)
    {
        var user = new User
        {
            Username = employeeDto.Username,
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            Email = employeeDto.Email,
            Password = employeeDto.Password, // Ensure password is hashed
            Role = "Employee", // Default role for the user
            DateJoined = DateTime.Now
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        var employee = new Employee
        {
            UserId = user.Id,
            PhoneNumber = employeeDto.PhoneNumber,
            Address = employeeDto.Address,
            Position = employeeDto.Position
        };

        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();

        return employee;
    }

    public async Task<Employee> UpdateAsync(int id, UpdateEmployeeDto employeeDto)
    {
        var employee = await _context.Employees.Include(e => e.User).FirstOrDefaultAsync(e => e.Id == id);

        if (employee == null)
        {
            return null;
        }

        employee.User.Username = employeeDto.Username;
        employee.User.FirstName = employeeDto.FirstName;
        employee.User.LastName = employeeDto.LastName;
        employee.User.Email = employeeDto.Email;
        employee.PhoneNumber = employeeDto.PhoneNumber;
        employee.Address = employeeDto.Address;
        employee.Position = employeeDto.Position;

        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        return await _context.Employees.Include(e => e.User).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _context.Employees.Include(e => e.User).ToListAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var employee = await _context.Employees.Include(e => e.User).FirstOrDefaultAsync(e => e.Id == id);

        if (employee == null)
        {
            return false;
        }

        _context.Employees.Remove(employee);

        if (employee.User != null)
        {
            _context.Users.Remove(employee.User); // Delete related user
        }

        await _context.SaveChangesAsync();
        return true;
    }
}
