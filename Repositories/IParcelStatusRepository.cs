using CargoManagementSystem.DTOs;

namespace CargoManagementSystem.Repositories
{
    public interface IParcelStatusRepository
    {
        Task<IEnumerable<ParcelStatusDto>> GetParcelStatusesByParcelIdAsync(int parcelId);
    }
    
}
