using CargoManagementSystem.Models;
using CargoManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryrouteController : ControllerBase
    {
        private readonly IDeliveryrouteRepository _deliveryrouteRepository;

        public DeliveryrouteController(IDeliveryrouteRepository deliveryrouteRepository)
        {
            _deliveryrouteRepository = deliveryrouteRepository;
        }

        // GET: api/Deliveryroute
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deliveryroute>>> GetDeliveryroutes()
        {
            var deliveryroutes = await _deliveryrouteRepository.GetAllDeliveryroutesAsync();
            return Ok(deliveryroutes);
        }

        // GET: api/Deliveryroute/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deliveryroute>> GetDeliveryroute(int id)
        {
            var deliveryroute = await _deliveryrouteRepository.GetDeliveryrouteByIdAsync(id);

            if (deliveryroute == null)
            {
                return NotFound();
            }

            return Ok(deliveryroute);
        }

        // POST: api/Deliveryroute
        [HttpPost]
        public async Task<ActionResult<Deliveryroute>> PostDeliveryroute(Deliveryroute deliveryroute)
        {
            var createdDeliveryroute = await _deliveryrouteRepository.AddDeliveryrouteAsync(deliveryroute);
            return CreatedAtAction(nameof(GetDeliveryroute), new { id = createdDeliveryroute.Id }, createdDeliveryroute);
        }

        // PUT: api/Deliveryroute/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryroute(int id, Deliveryroute deliveryroute)
        {
            if (id != deliveryroute.Id)
            {
                return BadRequest();
            }

            await _deliveryrouteRepository.UpdateDeliveryrouteAsync(deliveryroute);
            return NoContent();
        }

        // DELETE: api/Deliveryroute/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryroute(int id)
        {
            var result = await _deliveryrouteRepository.DeleteDeliveryrouteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
