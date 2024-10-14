using CargoManagementSystem.Models;
using CargoManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class DeliveryRouteController : ControllerBase
{
    private readonly DeliveryRouteService _service;

    public DeliveryRouteController(DeliveryRouteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetRoutes()
    {
        var routes = await _service.GetAllRoutesAsync();
        return Ok(routes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoute(int id)
    {
        var route = await _service.GetRouteByIdAsync(id);
        if (route == null) return NotFound();
        return Ok(route);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoute([FromBody] CreateDeliveryRouteDto createDto)
    {
        await _service.CreateRouteAsync(createDto);
        return CreatedAtAction(nameof(GetRoute), new { id = createDto }, createDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoute(int id, [FromBody] UpdateDeliveryRouteDto updateDto)
    {
        await _service.UpdateRouteAsync(id, updateDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoute(int id)
    {
        await _service.DeleteRouteAsync(id);
        return NoContent();
    }
}
