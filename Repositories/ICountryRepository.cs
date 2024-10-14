using CargoManagementSystem.DTOs;
using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Repositories
{
    public interface ICountryRepository
    {
        Task<List<CountryDto>> GetCountriesAsync();
        Task<Country> GetCountryByIdAsync(int id);
        Task<Country> GetCountryByNameAsync(string name);
        Task AddCountryAsync(Country country);
        Task UpdateCountryAsync(Country country);
        Task DeleteCountryAsync(Country country);
        Task<bool> CountryExistsByNameAsync(string name);
        Task<bool> CountryExistsByIdAsync(int id);
    }
}
