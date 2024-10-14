using CargoManagementSystem.Data;
using CargoManagementSystem.Models;
using CargoManagementSystem.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using CargoManagementSystem.Repositories;


[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly ICustomerService _customerService;


    public CustomerController(AppDbContext context, IConfiguration configuration,ICustomerRepository customerRepository,ICustomerService customerService  )
    {
        _context = context;
        _configuration = configuration;
        _customerService = customerService;

    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterCustomerDto registerDto)
    {
        
        var existingUser = _context.Users.FirstOrDefault(u => u.Email == registerDto.Email);
        if (existingUser != null)
        {
            return BadRequest("Email is already registered.");
        }

        
        if (registerDto.Password != registerDto.ConfirmPassword)
        {
            return BadRequest("Passwords do not match.");
        }

        
        var newUser = new User
        {
            Username = registerDto.Username,
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            Email = registerDto.Email,
            Password = registerDto.Password, 
            Role = "Customer",
            DateJoined = DateTime.Now
        };

        _context.Users.Add(newUser);
        _context.SaveChanges();

        var newCustomer = new Customer
        {
            UserId = newUser.Id,
            PhoneNumber = registerDto.PhoneNumber,
            Address = registerDto.Address
        };

        _context.Customers.Add(newCustomer);
        _context.SaveChanges();

        return Ok("Customer registered successfully.");
    }


    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password);
        if (user == null)
        {
            return Unauthorized("Invalid credentials.");
        }

        // Generate JWT token
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

    [HttpPost]
    public async Task<ActionResult<Customer>> CreateCustomer([FromBody] CreateCustomerDto customerDto)
    {
        var customer = await _customerService.CreateAsync(customerDto);
        return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerDto customerDto)
    {
        var updatedCustomer = await _customerService.UpdateAsync(id, customerDto);
        if (updatedCustomer == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomerById(int id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
    {
        var customers = await _customerService.GetAllAsync();
        return Ok(customers);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var success = await _customerService.DeleteAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}
