using Entity.Models;
using WebAPI.Model.Dto.Book;

namespace WebAPI.Services.Interfaces
{
    public interface IBookSevice
    {
        Task<BookResponseDto> GetBook(long id);
        Task DeleteBook(long id);
        Task<ICollection<AuthorResponseDto>> GetAuthors(long id);
        Task CreateBook(BookCreateDto bookCreate);
        Task UpdateBook(BookUpdateDto bookUpdate);
    }
}
