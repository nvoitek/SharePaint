using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharePaint.Models;
using SharePaint.Services.Interfaces;
using System.Threading.Tasks;

namespace SharePaint.API.Controllers
{
    // TODO: Split model and entity
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(User user) 
        {
            var token = await _userService.Login(user);

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest(new { Message = "Username or password is incorrect" });
            }

            return Ok(token);
        }
    }
}
