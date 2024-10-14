using CargoManagementSystem.DTOs;
using CargoManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CityDto>>> GetCitiesAsync()
        {
            var cities = await _cityService.GetCitiesAsync();
            return Ok(cities);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCityAsync([FromBody] CreateCityDto createCityDto)
        {
            await _cityService.CreateCityAsync(createCityDto);
            return CreatedAtAction(nameof(GetCitiesAsync), new { name = createCityDto.Name }, createCityDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCityAsync(int id, [FromBody] UpdateCityDto updateCityDto)
        {
            await _cityService.UpdateCityAsync(id, updateCityDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCityAsync(int id)
        {
            await _cityService.DeleteCityAsync(id);
            return NoContent();
        }
    }
}
