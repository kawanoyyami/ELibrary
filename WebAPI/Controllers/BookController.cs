using Entity.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model.Dto.Book;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookSevice _bookSevice { get; }
        public BookController(IBookSevice bookSevice)
        {
            _bookSevice = bookSevice;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(long id)
        {
            var result = await _bookSevice.GetBook(id);

            return Ok(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> CreateBook([FromBody] BookCreateDto bookCreateDto)
        {
            await _bookSevice.CreateBook(bookCreateDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(long id)
        {
            await _bookSevice.DeleteBook(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] BookUpdateDto bookModel)
        {
            await _bookSevice.UpdateBook(bookModel);
            return Ok();
        }
        [HttpGet("{id}/Authors")]
        public async Task<IActionResult> GetBookAuthor(long id)
        {
            var result = await _bookSevice.GetAuthors(id);
            return Ok(result);
        }
    }
}
