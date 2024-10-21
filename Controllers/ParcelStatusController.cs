using System.Linq;  // Ensure to include this for .Select() LINQ
using CargoManagementSystem.Models;
using CargoManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Controllers
{
 
    [ApiController]
    [Route("api/[controller]")]
    public class ParcelStatusController : ControllerBase
    {
        private readonly IParcelStatusService _parcelStatusService;

        public ParcelStatusController(IParcelStatusService parcelStatusService)
        {
            _parcelStatusService = parcelStatusService;
        }

        [HttpGet("{parcelId}")]
        public async Task<IActionResult> GetParcelStatuses(int parcelId)
        {
            var statuses = await _parcelStatusService.GetParcelStatusesAsync(parcelId);
            return Ok(new { statuses });
        }
    }
   
}