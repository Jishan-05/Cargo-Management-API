namespace CargoManagementSystem.DTOs
{
    public class RegisterCustomerDto
    {
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; } 
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
    }
}
