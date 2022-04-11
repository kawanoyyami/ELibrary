using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model.Dto.User;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private IAuthService _authSevice { get; }
        public AuthController(IAuthService authSevice)
        {
            _authSevice = authSevice;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Create(RegisterUserQueryDto registerUser)
        {
            var result = await _authSevice.RegisterUser(registerUser);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserQueryDto loginUser)
        {
            var result = await _authSevice.Login(loginUser);
            return Ok(result);
        }
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authSevice.LogOut();
            return Ok(new { });
        }
    }
}
