using Microsoft.EntityFrameworkCore;
using PatientViewerAPI.Models;

namespace PatientViewerAPI.Data
{
    public class PatientViewerDbContext(DbContextOptions<PatientViewerDbContext> options) : DbContext(options)
    {
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>().HasKey(p => p.Id);
            modelBuilder.Entity<Patient>().Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Patient>().Property(p => p.LastName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Patient>().Property(p => p.Age).IsRequired();
            modelBuilder.Entity<Patient>().Property(p => p.Gender).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Patient>().Property(p => p.Diagnosis).HasMaxLength(500);
            modelBuilder.Entity<Patient>().Property(p => p.CreatedAt).IsRequired();

            modelBuilder.Entity<Patient>().ToTable("Patients");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
