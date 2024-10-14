// IAdminRepository.cs
public interface IAdminRepository
{
    Task<List<AdminDto>> GetAdminListAsync();
}
