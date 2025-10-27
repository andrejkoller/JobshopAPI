using Microsoft.EntityFrameworkCore;
using JobshopAPI.Models;

namespace JobshopAPI.Data
{
    public class JobshopDbContext(DbContextOptions<JobshopDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var userEntity = modelBuilder.Entity<User>();

            userEntity.HasKey(u => u.Id);

            userEntity.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            userEntity.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            userEntity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            userEntity.HasIndex(u => u.Email)
                .IsUnique();

            userEntity.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(255);

            userEntity.Property(u => u.CompanyLocation)
                .HasMaxLength(255);

            userEntity.Property(u => u.PhoneNumber)
                .HasMaxLength(20);

            userEntity.Property(u => u.ProfilePictureUrl)
                .HasMaxLength(500);

            userEntity.Property(u => u.Role)
                .HasConversion<int>()
                .IsRequired()
                .HasDefaultValue(UserRole.JobSeeker);

            userEntity.Property(u => u.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            userEntity.Property(u => u.LastUpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            userEntity.ToTable("Users");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
