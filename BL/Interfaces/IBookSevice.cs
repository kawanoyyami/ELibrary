using Common.Dto.Book;
using Common.Models.PagedRequestModels;

namespace BL.Interfaces
{
    public interface IBookSevice
    {
        Task<BookResponseDto> GetBook(long id);
        Task DeleteBook(long id);
        Task<BookWithAuthorsDto> GetBookWithAuthors(long id);
        Task CreateBook(BookCreateDto bookCreate);
        Task<BookUpdateDto> UpdateBook(BookUpdateDto bookUpdate);
        Task<PaginatedResult<BookResponseDto>> GetPagedBooks(PagedRequest pagedRequest);
        Task<List<BookResponseDto>> GetAllBoks();
    }
}
