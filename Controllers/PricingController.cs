using CargoManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CargoManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly PricingService _pricingService;

        public PricingController(PricingService pricingService)
        {
            _pricingService = pricingService;
        }

        // GET: api/pricing
        [HttpGet]
        public async Task<IActionResult> GetAllPricing()
        {
            var pricing = await _pricingService.GetAllPricingAsync();
            return Ok(pricing);
        }

        // GET: api/pricing/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricingById(int id)
        {
            try
            {
                var pricing = await _pricingService.GetPricingByIdAsync(id);
                return Ok(pricing);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST: api/pricing
        [HttpPost]
        public async Task<IActionResult> CreatePricing([FromBody] CreatePricingDto createPricingDto)
        {
            await _pricingService.CreatePricingAsync(createPricingDto);
            return Ok(new { message = "Pricing record created successfully." });
        }

        // PUT: api/pricing/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePricing(int id, [FromBody] UpdatePricingDto updatePricingDto)
        {
            try
            {
                await _pricingService.UpdatePricingAsync(id, updatePricingDto);
                return Ok(new { message = "Pricing record updated successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: api/pricing/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePricing(int id)
        {
            try
            {
                await _pricingService.DeletePricingAsync(id);
                return Ok(new { message = "Pricing record deleted successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
