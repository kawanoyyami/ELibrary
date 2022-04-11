using Entity.Models;
using WebAPI.Model.Dto.Author;
using WebAPI.Services.Interfaces;
using Entity.Repository.Interfaces;
using AutoMapper;
using Common.Exceptions;
using Entity.Repository;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services
{
    public class AuthorService : IAuthorSevice
    {
        private readonly IRepository<Author> _authorRepository;
        private readonly IRepository<Book> _bookRepository;

        //@TO-DO refactor all with GenericRepository
        private IMapper _mapper { get; }
        public AuthorService(IRepository<Author> authorRepository, IRepository<Book> genericRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _bookRepository = genericRepository;
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
                throw new NotFoundException("Author doesn't exist!");
            await _authorRepository.Delete(id);
        }

        public async Task<AuthorResponseDto> GetAuthor(long id)
        {
            var res = await _authorRepository.GetByIdAsync(id);
            var output = _mapper.Map<AuthorResponseDto>(res);
            return output;
        }
        public async Task<BookResponseDto> GetBook(long id)
        {
            //@TO-DO make it to work
            //var author = _authorRepository.Get()
            var res = await _bookRepository.GetByIdAsync(id);
            //var res = _authorRepository.GetByIdAsync(id);
            var output = _mapper.Map<BookResponseDto>(res);
            return output;
        }
    }
}
