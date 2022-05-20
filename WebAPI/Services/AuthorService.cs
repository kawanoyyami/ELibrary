using Entity.Models;
using WebAPI.Model.Dto.Author;
using WebAPI.Services.Interfaces;
using AutoMapper;
using Common.Exceptions;
using Entity.Repository;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services
{
    public class AuthorService : IAuthorSevice
    {
        private readonly IRepository<Author> _authorRepository;
        private IMapper _mapper { get; }
        public AuthorService(IRepository<Author> authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task CreateAuthor(AuthorCreateDto bookCreate)
        {
            var author = _mapper.Map<Author>(bookCreate);
            await _authorRepository.AddAsync(author);
        }

        public async Task DeleteAuthor(long id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            if (author == null)
                throw new NotFoundException($"Author could not be deleted because author with id: {id} not exist in database!");

            await _authorRepository.Delete(id);
        }

        public async Task<AuthorResponseDto> GetAuthor(long id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            if (author == null)
                throw new NotFoundException("Author doesn't exist!");

            var output = _mapper.Map<AuthorResponseDto>(author);
            return output;
        }
        public async Task<AuthorWithBooksDto> GetAuthorWithBooks(long id)
        {
            var book = await _authorRepository.GetByIdWithIncludeAsync(id, b => b.Books);

            if (book == null)
                throw new NotFoundException("Author doesn't exist!");

            var output = _mapper.Map<AuthorWithBooksDto>(book);
            return output;
        }
    }
}
