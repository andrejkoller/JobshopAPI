using Microsoft.AspNetCore.Mvc;
using JobshopAPI.Services;
using Microsoft.AspNetCore.Authorization;

namespace JobshopAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(UserService service) : Controller
    {
        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await service.GetAllUsersAsync();
            return users == null || users.Count == 0 ? NotFound("No users found.") : Ok(users);
        }
    }
}
