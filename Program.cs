
using Microsoft.EntityFrameworkCore;
using JobshopAPI.Services;
using JobshopAPI.Data;
using System.Text.Json.Serialization;

namespace JobshopAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var policyName = "AllowAllOrigins";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(policyName,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:7292")
                               .AllowCredentials()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<JobshopDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddControllers().AddJsonOptions(options => {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            builder.Services.AddScoped<UserService>();
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
            }

            app.UseCors(policyName);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
