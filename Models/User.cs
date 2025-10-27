namespace JobshopAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? CompanyLocation { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? ProfilePictureUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;

        public UserRole Role { get; set; } = UserRole.JobSeeker;
    }

    public enum UserRole
    {
        Admin,
        Employer,
        JobSeeker
    }
}
