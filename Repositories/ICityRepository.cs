using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllCitiesAsync();
        Task<City?> GetCityByIdAsync(int id);
        Task<City> AddCityAsync(City city);
        Task<City> UpdateCityAsync(City city);
        Task<bool> DeleteCityAsync(int id);
    }
}
