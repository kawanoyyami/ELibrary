using Common.Models.PagedRequestModels;
using Entity.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model.Dto.Book;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "admin,FreeUser,PaidUser")]
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
        public async Task<IActionResult> GetBook(long id)
        {
            var result = await _bookSevice.GetBook(id);

            return Ok(result);
        }
        [HttpPost("add")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateBook(BookCreateDto bookCreateDto)
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
        public async Task<IActionResult> UpdateBook(BookUpdateDto bookModel)
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
