using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Repositories
{
    public interface ICityRepository
    {
        Task<List<City>> GetCitiesAsync();
        Task<City> GetCityByIdAsync(int id);
        Task<State> GetStateByNameAsync(string stateName);
        Task<bool> CityExistsInStateAsync(string cityName, int stateId);
        Task AddCityAsync(City city);
        Task UpdateCityAsync(City city);
        Task DeleteCityAsync(City city);
        Task<bool> CityExistsAsync(int id);
        
        // for booking
        Task<City?> GetCityByNameAsync(string cityName);


    }
}
