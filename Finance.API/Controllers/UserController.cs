using Finance.Application.Service;
using Finance.Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(User user, UserService userService)
        {
            await userService.Register(user.UserName, user.Email, user.PasswordHash);
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(User user, UserService userService)
        {
            var token = await userService.Login(user.Email, user.PasswordHash);

            this.HttpContext.Response.Cookies.Append("tasty-cookes", token);

            return Ok();
        }
    }
}
