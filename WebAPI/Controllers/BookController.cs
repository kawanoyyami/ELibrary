using BL.Interfaces;
using Common.Dto.Book;
using Common.Models.PagedRequestModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private IBookSevice _bookSevice { get; }
        public BookController(IBookSevice bookSevice)
        {
            _bookSevice = bookSevice;
        }
        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<BookResponseDto>> GetPagedBooks(PagedRequest pagedRequest)
        {
            var pagedBooksDto = await _bookSevice.GetPagedBooks(pagedRequest);
            return pagedBooksDto;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(long id)
        {
            var result = await _bookSevice.GetBook(id);

            return Ok(result);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await _bookSevice.GetAllBoks();

            return Ok(result);
        }

        [HttpPost("add")]
        [Authorize(Roles = "admin")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> CreateBook([FromForm] BookCreateDto bookCreateDto)
        {
            await _bookSevice.CreateBook(bookCreateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteBook(long id)
        {
            await _bookSevice.DeleteBook(id);
            return Ok();
        }
        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateBook([FromForm] BookUpdateDto bookModel)
        {
            if (ModelState.IsValid)
            {
                await _bookSevice.UpdateBook(bookModel);
                return Ok();

            }
            return BadRequest(ModelState);
        }
        [HttpGet("{id}/Authors")]
        public async Task<IActionResult> GetBookAuthor(long id)
        {
            var result = await _bookSevice.GetBookWithAuthors(id);
            return Ok(result);
        }
    }
}
