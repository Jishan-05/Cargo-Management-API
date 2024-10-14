using CargoManagementSystem.DTOs;
using CargoManagementSystem.Models;
using CargoManagementSystem.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Services
{
    public class CountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        // Get all countries with optional search by country name
        public async Task<List<CountryDto>> GetCountriesAsync()
        {
            return await _countryRepository.GetCountriesAsync();
        }

        // Create a new country
        public async Task CreateCountryAsync(CreateCountryDto createCountryDto)
        {
            if (await _countryRepository.CountryExistsByNameAsync(createCountryDto.Name))
            {
                throw new InvalidOperationException("The Country Already Exists");
            }

            var country = new Country
            {
                Name = createCountryDto.Name
            };

            await _countryRepository.AddCountryAsync(country);
        }

        // Update an existing country
        public async Task UpdateCountryAsync(int id, UpdateCountryDto updateCountryDto)
        {
            var country = await _countryRepository.GetCountryByIdAsync(id);
            if (country == null)
            {
                throw new KeyNotFoundException("Can't Find Country");
            }

            country.Name = updateCountryDto.Name;

            if (await _countryRepository.CountryExistsByNameAsync(country.Name))
            {
                throw new InvalidOperationException("The Country Already Exists");
            }

            await _countryRepository.UpdateCountryAsync(country);
        }

        // Delete a country
        public async Task DeleteCountryAsync(int id)
        {
            var country = await _countryRepository.GetCountryByIdAsync(id);
            if (country == null)
            {
                throw new KeyNotFoundException("Can't Find Country");
            }

            await _countryRepository.DeleteCountryAsync(country);
        }
    }
}
