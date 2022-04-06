using Entity.Models;
using WebAPI.Model.Dto.Author;
using WebAPI.Services.Interfaces;
using Entity.Repository.Interfaces;
using AutoMapper;
using Common.Exceptions;

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

        public async Task DeleteAuthor(long id)
        {
            var author = await _authorRepository.GetEntity(id);
            if (author == null)
                throw new NotFoundException("Author doesn't exist!");
            await _authorRepository.Delete(author);
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
