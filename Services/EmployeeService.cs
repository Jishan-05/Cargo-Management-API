using CargoManagementSystem.Models;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public Task<Employee> CreateAsync(CreateEmployeeDto employeeDto)
    {
        return _employeeRepository.CreateAsync(employeeDto);
    }

    public Task<Employee> UpdateAsync(int id, UpdateEmployeeDto employeeDto)
    {
        return _employeeRepository.UpdateAsync(id, employeeDto);
    }

    public Task<Employee> GetByIdAsync(int id)
    {
        return _employeeRepository.GetByIdAsync(id);
    }

    public Task<IEnumerable<Employee>> GetAllAsync()
    {
        return _employeeRepository.GetAllAsync();
    }

    public Task<bool> DeleteAsync(int id)
    {
        return _employeeRepository.DeleteAsync(id);
    }
}
