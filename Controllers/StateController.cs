using CargoManagementSystem.DTOs;
using CargoManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly StateService _stateService;

        public StateController(StateService stateService)
        {
            _stateService = stateService;
        }

        // GET: api/State
        [HttpGet]
        public async Task<ActionResult<List<StateDto>>> GetStates()
        {
            var states = await _stateService.GetStatesAsync();
            return Ok(states);
        }

        // POST: api/State
        [HttpPost]
        public async Task<ActionResult> CreateState([FromBody] CreateStateDto createStateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _stateService.CreateStateAsync(createStateDto);
                return CreatedAtAction(nameof(GetStates), new { name = createStateDto.Name }, createStateDto);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        // PUT: api/State/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateState(int id, [FromBody] UpdateStateDto updateStateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _stateService.UpdateStateAsync(id, updateStateDto);
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

        // DELETE: api/State/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteState(int id)
        {
            try
            {
                await _stateService.DeleteStateAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
