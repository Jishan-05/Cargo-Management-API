using CargoManagementSystem.Data;
using CargoManagementSystem.Models;
using CargoManagementSystem.DTOs;
using CargoManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;


[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly IAdminService _adminService;


    public AdminController(AppDbContext context, IConfiguration configuration, IAdminService adminService)
    {
        _context = context;
        _configuration = configuration;
        _adminService = adminService;
    }

    [HttpGet("admin-list")]
    public async Task<IActionResult> GetAdminList()
    {
        var adminList = await _adminService.GetAllAdminsAsync();
        if (adminList == null || adminList.Count == 0)
        {
            return NotFound("No admins found.");
        }
        return Ok(adminList);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] AdminLoginDto loginDto)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == loginDto.Username && u.Password == loginDto.Password);
        if (user == null)
        {
            return Unauthorized("Invalid credentials.");
        }

        
        var token = GenerateJwtToken(user);

        return Ok(new { Token = token });
    }

    private string GenerateJwtToken(User user)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var tokenOptions = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryMinutes"])),
            signingCredentials: signinCredentials
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return tokenString;
    }
}
