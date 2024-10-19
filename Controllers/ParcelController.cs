using System.Linq;  // Ensure to include this for .Select() LINQ
using CargoManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelController : ControllerBase
    {
        private readonly ParcelService _parcelService;

        public ParcelController(ParcelService parcelService)
        {
            _parcelService = parcelService;
        }

        // GET: api/parcel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParcelDto>>> GetAllParcels()
        {
            var parcels = await _parcelService.GetAllParcelsAsync();
            
            if (parcels == null)
            {
                return NotFound();
            }
            
            // Map the Parcel entity to ParcelDto including Id
            var parcelDtos = parcels.Select(p => new ParcelDto
            {
                Id = p.Id,  // Include the Id in the response
                CustomerName = $"{p.Customer.User.FirstName} {p.Customer.User.LastName}",
                TrackingId = p.TrackingId,
                ParcelType = p.ParcelType,
                Status = p.Status
            }).ToList();

            return Ok(parcelDtos);
        }

        // GET: api/parcel/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ParcelDto>> GetParcelById(int id)
        {
            var parcel = await _parcelService.GetParcelByIdAsync(id);
            
            if (parcel == null)
            {
                return NotFound();
            }

            // Map the Parcel entity to ParcelDto including Id
            var parcelDto = new ParcelDto
            {
                Id = parcel.Id,  // Include the Id in the response
                CustomerName = $"{parcel.Customer.User.FirstName} {parcel.Customer.User.LastName}",
                TrackingId = parcel.TrackingId,
                ParcelType = parcel.ParcelType,
                Status = parcel.Status
            };

            return Ok(parcelDto);
        }
    }
}
