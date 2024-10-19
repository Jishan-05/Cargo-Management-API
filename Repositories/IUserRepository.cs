using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks; 
namespace CargoManagementSystem.Repositories
{
    public interface IUserRepository
    {
        Task<int> GetTotalUsersAsync();
        Task<int> GetTotalCustomersAsync();
        Task<int> GetTotalEmployeesAsync();
    }    
}
