using System.ComponentModel.DataAnnotations;

public class CreateCustomerDto
{
    [Required]
    public string? Username { get; set; }

    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [Phone]
    public string? PhoneNumber { get; set; }

    [Required]
    public string? Address { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 6)]
    public string? Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string? ConfirmPassword { get; set; }
}
