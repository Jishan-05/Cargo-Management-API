using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICustomerService
{
    Task<Customer> CreateAsync(CreateCustomerDto customerDto);
    Task<Customer> UpdateAsync(int id, UpdateCustomerDto customerDto);
    Task<Customer> GetByIdAsync(int id);
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<bool> DeleteAsync(int id);
}