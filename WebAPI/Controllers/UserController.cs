using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model.Dto.User;
using WebAPI.Services.Interfaces;

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
        public async Task<IActionResult> GetUser(long id)
        {
            var res = await _userService.GetUser(id);
            return Ok(res);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody]UserUpdateDto userUpdateDto)
        {
            var res = await _userService.UpdateUser(userUpdateDto);
            return Ok();
        }
        [HttpGet("{id}/projects")]
        public async Task<IActionResult> GetUserProjects(long id)
        {
            var res = await _userService.GetUserProject(id);
            return Ok(res);
        }
        [HttpGet("{id}/reports")]
        public async Task<IActionResult> GetUserReports(long id)
        {
            var res = await _userService.GetUserReport(id);
            return Ok(res);
        }
    }
}
