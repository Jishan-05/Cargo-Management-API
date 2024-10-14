using System.ComponentModel.DataAnnotations;

public class UpdateCustomerDto
{
    [Required]
    public string? Username { get; set; }

    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }[Required]
    public string? PhoneNumber { get; set; }

    [Required]
    public string? Address { get; set; }
}
