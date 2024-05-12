using Finance.Application.DTOs;
using Finance.Application.Service;
using Finance.Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto newIncome)
        {
            await userService.Register(newIncome);
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserDto user)
        {
            var token = await userService.Login(user);

            this.HttpContext.Response.Cookies.Append("tasty-cookes", token);

            return Ok();
        }
    }
}
