using CargoManagementSystem.DTOs;
using CargoManagementSystem.Models;
using CargoManagementSystem.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoManagementSystem.Services
{
    public class CityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<List<CityDto>> GetCitiesAsync()
        {
            var cities = await _cityRepository.GetCitiesAsync();
            return cities.Select(c => new CityDto
            {
                CityName = c.Name,
                Address = c.Address,
                StateName = c.State.Name,
                CountryName = c.State.Country.Name
            }).ToList();
        }

        public async Task CreateCityAsync(CreateCityDto createCityDto)
        {
            var state = await _cityRepository.GetStateByNameAsync(createCityDto.StateName);
            if (state == null)
            {
                throw new KeyNotFoundException("State not found");
            }

            if (await _cityRepository.CityExistsInStateAsync(createCityDto.Name, state.Id))
            {
                throw new InvalidOperationException("City already exists in this state");
            }

            var city = new City
            {
                Name = createCityDto.Name,
                Address = createCityDto.Address,
                StateId = state.Id
            };

            await _cityRepository.AddCityAsync(city);
        }

        public async Task UpdateCityAsync(int id, UpdateCityDto updateCityDto)
        {
            var city = await _cityRepository.GetCityByIdAsync(id);
            if (city == null)
            {
                throw new KeyNotFoundException("City not found");
            }

            var state = await _cityRepository.GetStateByNameAsync(updateCityDto.StateName);
            if (state == null)
            {
                throw new KeyNotFoundException("State not found");
            }

            city.Name = updateCityDto.Name;
            city.Address = updateCityDto.Address;
            city.StateId = state.Id;

            if (await _cityRepository.CityExistsInStateAsync(city.Name, city.StateId  ?? 0) && city.Id != id)
            {
                throw new InvalidOperationException("The city already exists in this state.");
            }

            await _cityRepository.UpdateCityAsync(city);
        }

        public async Task DeleteCityAsync(int id)
        {
            var city = await _cityRepository.GetCityByIdAsync(id);
            if (city == null)
            {
                throw new KeyNotFoundException("City not found");
            }

            await _cityRepository.DeleteCityAsync(city);
        }
    }
}
