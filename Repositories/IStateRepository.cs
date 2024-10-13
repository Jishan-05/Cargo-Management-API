using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Repositories
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> GetAllStatesAsync();
        Task<State?> GetStateByIdAsync(int id);
        Task<State> AddStateAsync(State state);
        Task<State> UpdateStateAsync(State state);
        Task<bool> DeleteStateAsync(int id);
    }
}
