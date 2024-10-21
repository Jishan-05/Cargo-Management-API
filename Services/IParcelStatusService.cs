using CargoManagementSystem.DTOs;

namespace CargoManagementSystem.Services
{
    public interface IParcelStatusService
    {
        Task<IEnumerable<ParcelStatusDto>> GetParcelStatusesAsync(int parcelId);
    }    
}
