using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Repositories
{
    public interface IStateRepository
    {
        Task<List<State>> GetStatesAsync();
        Task<State> GetStateByIdAsync(int id);
        Task AddStateAsync(State state);
        Task UpdateStateAsync(State state);
        Task DeleteStateAsync(State state);
        Task<bool> StateExistsInCountryAsync(string stateName, int countryId);
        Task<Country> GetCountryByNameAsync(string countryName);
    }
}
