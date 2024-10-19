using CargoManagementSystem.Models;

public interface IParcelRepository
{
    Task<IEnumerable<Parcel>> GetAllParcelsAsync();
    Task<Parcel> GetParcelByIdAsync(int id);

}

