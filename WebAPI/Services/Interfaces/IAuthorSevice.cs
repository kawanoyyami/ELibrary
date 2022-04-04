using Entity.Models;
using WebAPI.Model.Dto.Author;

namespace WebAPI.Services.Interfaces
{
    public interface IAuthorSevice
    {
        Task<AuthorResponseDto> GetAuthor(long id);
        Task DeleteAuthor(long id);
        Task<ICollection<BookResponseDto>> GetBooks(long id);
        Task CreateAuthor(AuthorCreateDto bookCreate);

    }
}
