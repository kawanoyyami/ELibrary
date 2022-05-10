using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model.Dto.Author;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "admin,FreeUser,PaidUser")]
    public class AuthorController : ControllerBase
    {
        private IAuthorSevice _authorSevice { get; }
        public AuthorController(IAuthorSevice author)
        {
            _authorSevice = author;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(long id)
        {
            var result = await _authorSevice.GetAuthor(id);
            return Ok(result);
        }
        [HttpPost("add")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddAuthor(AuthorCreateDto authorCreateDto)
        {
            await _authorSevice.CreateAuthor(authorCreateDto);
            return Ok();
        }
        [HttpGet("{id}/Books")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBookAuthor(long id)
        {
            var result = await _authorSevice.GetAuthorWithBooks(id);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteBook(long id)
        {
            await _authorSevice.DeleteAuthor(id);
            return Ok();
        }
    }
}
