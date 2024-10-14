using CargoManagementSystem.Models;

public interface IEmployeeService
{
    Task<Employee> CreateAsync(CreateEmployeeDto employeeDto);
    Task<Employee> UpdateAsync(int id, UpdateEmployeeDto employeeDto);
    Task<Employee> GetByIdAsync(int id);
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<bool> DeleteAsync(int id);
}