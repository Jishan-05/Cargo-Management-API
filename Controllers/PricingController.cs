using CargoManagementSystem.Models;
using CargoManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IPricingRepository _pricingRepository;

        public PricingController(IPricingRepository pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        // GET: api/Pricing
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pricing>>> GetPricings()
        {
            var pricings = await _pricingRepository.GetAllPricingsAsync();
            return Ok(pricings);
        }

        // GET: api/Pricing/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pricing>> GetPricing(int id)
        {
            var pricing = await _pricingRepository.GetPricingByIdAsync(id);

            if (pricing == null)
            {
                return NotFound();
            }

            return Ok(pricing);
        }

        // POST: api/Pricing
        [HttpPost]
        public async Task<ActionResult<Pricing>> PostPricing(Pricing pricing)
        {
            var createdPricing = await _pricingRepository.AddPricingAsync(pricing);
            return CreatedAtAction(nameof(GetPricing), new { id = createdPricing.Id }, createdPricing);
        }

        // PUT: api/Pricing/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPricing(int id, Pricing pricing)
        {
            if (id != pricing.Id)
            {
                return BadRequest();
            }

            await _pricingRepository.UpdatePricingAsync(pricing);
            return NoContent();
        }

        // DELETE: api/Pricing/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePricing(int id)
        {
            var result = await _pricingRepository.DeletePricingAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
