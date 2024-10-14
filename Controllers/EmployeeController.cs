using CargoManagementSystem.Data;
using CargoManagementSystem.Models;
using CargoManagementSystem.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using CargoManagementSystem.Repositories;
using CargoManagementSystem.Services;


[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly IEmployeeRepository _employeeRepository;

    private readonly IEmployeeService _employeeService;

    public EmployeeController(AppDbContext context, IConfiguration configuration, IEmployeeRepository employeeRepository, IEmployeeService employeeService )
    {
        _context = context;
        _configuration = configuration;
        _employeeRepository = employeeRepository;
        _employeeService = employeeService;

    }
    
    
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password);
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



    // POST: api/Employee
    [HttpPost]
    public async Task<ActionResult<Employee>> CreateEmployee([FromBody] CreateEmployeeDto employeeDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var employee = await _employeeService.CreateAsync(employeeDto);
        if (employee == null)
        {
            return BadRequest("Failed to create employee.");
        }

        // Returning the created employee with a link to its newly created resource
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeDto employeeDto)
    {
        var updatedEmployee = await _employeeService.UpdateAsync(id, employeeDto);
        if (updatedEmployee == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetEmployeeById(int id)
    {
        var employee = await _employeeService.GetByIdAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
    {
        var employees = await _employeeService.GetAllAsync();
        return Ok(employees);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var success = await _employeeService.DeleteAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}
