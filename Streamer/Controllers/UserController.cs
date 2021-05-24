using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Streamer.Interfaces;
using Streamer.Models;

namespace Streamer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserModel user)
        {
            if (_userService.CheckUserExists(user))
            {
                return Problem();
            }

            await _userService.CreateUser(user);
            var token = _userService.AuthenticateUser(user);
            return Ok(token);
        }

        [HttpPost("login")]
        public IActionResult Login(UserModel user)
        {
            var token = _userService.AuthenticateUser(user);
            if (token == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
            return Ok(token);
        }
    }
}
