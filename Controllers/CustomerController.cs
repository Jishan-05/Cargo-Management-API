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

    private readonly ICustomerRepository _customerRepository;

    public CustomerController(AppDbContext context, IConfiguration configuration,ICustomerRepository customerRepository )
    {
        _context = context;
        _configuration = configuration;
        _customerRepository = customerRepository;
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

    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
    {
        var customers = await _customerRepository.GetAllCustomersAsync();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomer(int id)
    {
        var customer = await _customerRepository.GetCustomerByIdAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
    {
        var createdCustomer = await _customerRepository.CreateCustomerAsync(customer);
        return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomer.Id }, createdCustomer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
    {
        if (id != customer.Id)
        {
            return BadRequest();
        }

        await _customerRepository.UpdateCustomerAsync(customer);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        await _customerRepository.DeleteCustomerAsync(id);
        return NoContent();
    }
}
