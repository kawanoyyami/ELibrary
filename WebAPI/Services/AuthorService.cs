using Entity.Models;
using WebAPI.Model.Dto.Author;
using WebAPI.Services.Interfaces;
using Entity.Repository.Interfaces;
using AutoMapper;

namespace WebAPI.Services
{
    public class AuthorService : IAuthorSevice
    {
        private IAuthorRepository _authorRepository { get; }
        private IMapper _mapper { get; }
        public AuthorService(IAuthorRepository authorRepository,IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task CreateAuthor(AuthorCreateDto bookCreate)
        {
            var author = _mapper.Map<Author>(bookCreate);
            var res = await _authorRepository.AddAuthor(author);
        }

        public Task DeleteAuthor(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthorResponseDto> GetAuthor(long id)
        {
            var res = await _authorRepository.GetByIdAsync(id);
            var output = _mapper.Map<AuthorResponseDto>(res);
            return output;
        }

        public async Task<ICollection<BookResponseDto>> GetBooks(long id)
        {
            var res = await _authorRepository.GetBook(id);
            var output = _mapper.Map<ICollection<BookResponseDto>>(res);
            return output;
        }
    }
}
