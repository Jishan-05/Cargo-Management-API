using CargoManagementSystem.Models;

public interface IParcelRepository
{
    Task<Parcel> GetParcelByIdAsync(int id);

}
