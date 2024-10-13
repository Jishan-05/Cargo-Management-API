using CargoManagementSystem.Models;
using CargoManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateRepository _stateRepository;

        public StateController(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        // GET: api/State
        [HttpGet]
        public async Task<ActionResult<IEnumerable<State>>> GetStates()
        {
            var states = await _stateRepository.GetAllStatesAsync();
            return Ok(states);
        }

        // GET: api/State/5
        [HttpGet("{id}")]
        public async Task<ActionResult<State>> GetState(int id)
        {
            var state = await _stateRepository.GetStateByIdAsync(id);

            if (state == null)
            {
                return NotFound();
            }

            return Ok(state);
        }

        // POST: api/State
        [HttpPost]
        public async Task<ActionResult<State>> PostState(State state)
        {
            var createdState = await _stateRepository.AddStateAsync(state);
            return CreatedAtAction(nameof(GetState), new { id = createdState.Id }, createdState);
        }

        // PUT: api/State/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutState(int id, State state)
        {
            if (id != state.Id)
            {
                return BadRequest();
            }

            await _stateRepository.UpdateStateAsync(state);
            return NoContent();
        }

        // DELETE: api/State/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteState(int id)
        {
            var result = await _stateRepository.DeleteStateAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
