using System.Collections.Generic;
using System.Threading.Tasks;
using CargoManagementSystem.Models;
using CargoManagementSystem.DTOs;
using CargoManagementSystem.Repositories;
namespace CargoManagementSystem.Services
{
 
    public class ParcelStatusService  :  IParcelStatusService

    {
        private readonly IParcelStatusRepository _parcelStatusRepository;

        public ParcelStatusService(IParcelStatusRepository parcelStatusRepository)
        {
            _parcelStatusRepository = parcelStatusRepository;
        }

        public async Task<IEnumerable<ParcelStatusDto>> GetParcelStatusesAsync(int parcelId)
        {
            return await _parcelStatusRepository.GetParcelStatusesByParcelIdAsync(parcelId);
        }
    }
   
}