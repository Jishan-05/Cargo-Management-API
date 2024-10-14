// IAdminService.cs
public interface IAdminService
{
    Task<List<AdminDto>> GetAllAdminsAsync();
}
