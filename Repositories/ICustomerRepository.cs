using CargoManagementSystem.Models;

public interface ICustomerRepository
{
    Task<Customer> CreateAsync(CreateCustomerDto customerDto);
    Task<Customer> UpdateAsync(int id, UpdateCustomerDto customerDto);
    Task<Customer> GetByIdAsync(int id);
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<bool> DeleteAsync(int id);


// for booking
    Task<Customer> GetCustomerByIdAsync(int id);

}

