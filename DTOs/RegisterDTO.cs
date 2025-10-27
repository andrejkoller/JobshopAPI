using JobshopAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace JobshopAPI.DTOs
{
    public class RegisterDTO
    {
        [Required, MinLength(3)]
        public string FirstName { get; set; } = string.Empty;
        [Required, MinLength(3)]
        public string LastName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, MinLength(12)]
        public string Password { get; set; } = string.Empty;
        [Required, Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
        public string? CompanyLocation { get; set; } = string.Empty;
        [Phone]
        public string? PhoneNumber { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.JobSeeker;
    }
}
