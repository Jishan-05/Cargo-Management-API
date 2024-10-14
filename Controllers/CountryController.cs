using CargoManagementSystem.DTOs;
using CargoManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;

        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }

        // GET: api/Country
        [HttpGet]
        public async Task<ActionResult<List<CountryDto>>> GetCountries()
        {
            var countries = await _countryService.GetCountriesAsync();
            return Ok(countries);
        }

        // POST: api/Country
        [HttpPost]
        public async Task<ActionResult> CreateCountry([FromBody] CreateCountryDto createCountryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _countryService.CreateCountryAsync(createCountryDto);
                return CreatedAtAction(nameof(GetCountries), new { name = createCountryDto.Name }, createCountryDto);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        // PUT: api/Country/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCountry(int id, [FromBody] UpdateCountryDto updateCountryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _countryService.UpdateCountryAsync(id, updateCountryDto);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        // DELETE: api/Country/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            try
            {
                await _countryService.DeleteCountryAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
