// AdminService.cs
public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;

    public AdminService(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<List<AdminDto>> GetAllAdminsAsync()
    {
        return await _adminRepository.GetAdminListAsync();
    }
}
