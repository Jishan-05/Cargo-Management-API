

using CargoManagementSystem.Models;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task<Customer> CreateAsync(CreateCustomerDto customerDto)
    {
        return _customerRepository.CreateAsync(customerDto);
    }

    public Task<Customer> UpdateAsync(int id, UpdateCustomerDto customerDto)
    {
        return _customerRepository.UpdateAsync(id, customerDto);
    }

    public Task<Customer> GetByIdAsync(int id)
    {
        return _customerRepository.GetByIdAsync(id);
    }

    public Task<IEnumerable<Customer>> GetAllAsync()
    {
        return _customerRepository.GetAllAsync();
    }

    public Task<bool> DeleteAsync(int id)
    {
        return _customerRepository.DeleteAsync(id);
    }
}
