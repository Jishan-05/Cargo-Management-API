using System.Collections.Generic;
using System.Threading.Tasks;
using CargoManagementSystem.Models;

public class ParcelService
{
    private readonly IParcelRepository _parcelRepository;

    public ParcelService(IParcelRepository parcelRepository)
    {
        _parcelRepository = parcelRepository;
    }

    public async Task<IEnumerable<Parcel>> GetAllParcelsAsync()
    {
        return await _parcelRepository.GetAllParcelsAsync();
    }

    public async Task<Parcel> GetParcelByIdAsync(int id)
    {
        return await _parcelRepository.GetParcelByIdAsync(id);
    }
}
