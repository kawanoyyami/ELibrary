using Entity.Models;
using WebAPI.Model.Dto.Book;

namespace WebAPI.Services.Interfaces
{
    public interface IBookSevice
    {
        Task<BookResponseDto> GetBook(long id);
        Task DeleteBook(long id);
        Task<BookWithAuthorsDto> GetBookWithAuthors(long id);
        Task CreateBook(BookCreateDto bookCreate);
        Task<BookUpdateDto> UpdateBook(BookUpdateDto bookUpdate);

    }
}
