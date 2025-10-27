using Microsoft.EntityFrameworkCore;
using JobshopAPI.Models;
using JobshopAPI.Data;

namespace JobshopAPI.Services
{
    public class UserService(JobshopDbContext context)
    {
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await context.Users.ToListAsync();
        }
    }
}
