using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model.Dto.Author;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        [AllowAnonymous]
        public async Task<IActionResult> AddAuthor([FromBody] AuthorCreateDto authorCreateDto)
        {
            await _authorSevice.CreateAuthor(authorCreateDto);
            return Ok();
        }
        [HttpGet("{id}/Book")]
        public async Task<IActionResult> GetBookAuthor(long id)
        {
            var result = await _authorSevice.GetBooks(id);
            return Ok(result);
        }
    }
}
