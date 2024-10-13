using CargoManagementSystem.Models;
using CargoManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactusRepository _repository;

        public ContactUsController(IContactusRepository repository)
        {
            _repository = repository;
        }

        // GET: api/contactus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contactus>>> GetAllContactUs()
        {
            var contactUsList = await _repository.GetAllAsync();
            return Ok(contactUsList);
        }

        // GET: api/contactus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contactus>> GetContactUs(int id)
        {
            var contactUs = await _repository.GetByIdAsync(id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return Ok(contactUs);
        }

        // POST: api/contactus
        [HttpPost]
        public async Task<ActionResult<Contactus>> PostContactUs(Contactus contactUs)
        {
            if (contactUs == null)
            {
                return BadRequest();
            }

            await _repository.CreateAsync(contactUs);
            return CreatedAtAction(nameof(GetContactUs), new { id = contactUs.Id }, contactUs);
        }

        // PUT: api/contactus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactUs(int id, Contactus contactUs)
        {
            if (id != contactUs.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repository.UpdateAsync(contactUs);
            }
            catch (Exception)
            {
                if (!await ContactUsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/contactus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactUs(int id)
        {
            var contactUs = await _repository.GetByIdAsync(id);
            if (contactUs == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> ContactUsExists(int id)
        {
            return await _repository.GetByIdAsync(id) != null;
        }
    }
}
