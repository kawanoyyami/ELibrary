using BL.Interfaces;
using Common.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserService _userService { get; }
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUser(long id)
        {
            var res = await _userService.GetUser(id);
            return Ok(res);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }
        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateUser(UserUpdateDto userUpdateDto)
        {
            var res = await _userService.UpdateUser(userUpdateDto);
            return Ok();
        }
        [HttpGet("{id}/projects")]
        public async Task<IActionResult> GetUserProjects(long id)
        {
            var res = await _userService.GetUserWithProjects(id);
            return Ok(res);
        }
    }
}
