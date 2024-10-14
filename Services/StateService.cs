using CargoManagementSystem.DTOs;
using CargoManagementSystem.Models;
using CargoManagementSystem.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoManagementSystem.Services
{
    public class StateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<List<StateDto>> GetStatesAsync()
        {
            var states = await _stateRepository.GetStatesAsync();
            return states.Select(s => new StateDto
            {
                StateName = s.Name,
                CountryName = s.Country.Name
            }).ToList();
        }

        public async Task CreateStateAsync(CreateStateDto createStateDto)
        {
            var country = await _stateRepository.GetCountryByNameAsync(createStateDto.CountryName);
            if (country == null)
            {
                throw new KeyNotFoundException("Country not found");
            }

            if (await _stateRepository.StateExistsInCountryAsync(createStateDto.Name, country.Id))
            {
                throw new InvalidOperationException("State already exists in this country");
            }

            var state = new State
            {
                Name = createStateDto.Name,
                CountryId = country.Id
            };

            await _stateRepository.AddStateAsync(state);
        }

        public async Task UpdateStateAsync(int id, UpdateStateDto updateStateDto)
        {
            var state = await _stateRepository.GetStateByIdAsync(id);
            if (state == null)
            {
                throw new KeyNotFoundException("State not found");
            }

            var country = await _stateRepository.GetCountryByNameAsync(updateStateDto.CountryName);
            if (country == null)
            {
                throw new KeyNotFoundException("Country not found");
            }

            if (await _stateRepository.StateExistsInCountryAsync(updateStateDto.Name, country.Id) && state.Id != id)
            {
                throw new InvalidOperationException("State already exists in this country");
            }

            state.Name = updateStateDto.Name;
            state.CountryId = country.Id;

            await _stateRepository.UpdateStateAsync(state);
        }

        public async Task DeleteStateAsync(int id)
        {
            var state = await _stateRepository.GetStateByIdAsync(id);
            if (state == null)
            {
                throw new KeyNotFoundException("State not found");
            }

            await _stateRepository.DeleteStateAsync(state);
        }
    }
}
