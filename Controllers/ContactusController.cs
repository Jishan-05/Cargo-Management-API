using CargoManagementSystem.DTOs;
using CargoManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using CargoManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contactus>>> GetAll()
        {
            var contactUsList = await _contactUsService.GetAllContactUsAsync();
            return Ok(contactUsList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contactus>> GetById(int id)
        {
            var contactUs = await _contactUsService.GetContactUsByIdAsync(id);

            if (contactUs == null)
            {
                return NotFound();
            }

            return Ok(contactUs);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateContactUsDto createContactUsDto)
        {
            if (createContactUsDto == null)
            {
                return BadRequest();
            }

            // Map CreateContactUsDto to Contactus model
            var contactUs = new Contactus
            {
                Name = createContactUsDto.Name,
                Email = createContactUsDto.Email,
                PhoneNumber = createContactUsDto.PhoneNumber,
                Message = createContactUsDto.Message
            };

            await _contactUsService.AddContactUsAsync(contactUs);

            // Assuming Contactus has an Id property
            return CreatedAtAction(nameof(GetById), new { id = contactUs.Id }, contactUs);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, UpdateContactUsDto updateContactUsDto)
        {
            if (updateContactUsDto == null)
            {
                return BadRequest();
            }

            // Map UpdateContactUsDto to Contactus model
            var contactUs = new Contactus
            {
                Id = id,  // Ensure the ID is set to the correct value
                Name = updateContactUsDto.Name,
                Email = updateContactUsDto.Email,
                PhoneNumber = updateContactUsDto.PhoneNumber,
                Message = updateContactUsDto.Message
            };

            await _contactUsService.UpdateContactUsAsync(id, contactUs);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _contactUsService.DeleteContactUsAsync(id);
            return NoContent();
        }
    }
}
