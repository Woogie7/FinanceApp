using Finance.Application.DTOs.UserDto;
using Finance.Application.Service;
using Finance.Domain.Entities.Users;
using Finance.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto newIncome)
        {
            try
            {
                await _userService.Register(newIncome);
                return Ok();
            }
            catch (UserAlreadyExistsException ex)
            { 

                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", detail = ex.Message });
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserDto user)
        {
            try
            {
                var token = await _userService.Login(user);
                this.HttpContext.Response.Cookies.Append("tasty-cookes", token);
                return Ok(token);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidPasswordException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", detail = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("GetBalance")]
        public async Task<IActionResult> GetBalance()
        {
            var userId = User.FindFirst("userId")?.Value;

            var balance = await _userService.GetBalance(userId);

            return Ok(balance);
        }
    }
}
