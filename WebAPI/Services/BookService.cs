using AutoMapper;
using Entity.Models;
using Entity.Repository.Interfaces;
using WebAPI.Model.Dto.Book;
using WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Services
{
    public class BookService : IBookSevice
    {
        private IBookRepository _bookRepository { get; }
        private IMapper _mapper { get; }
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task CreateBook(BookCreateDto bookCreate)
        {
            var book = _mapper.Map<Book>(bookCreate);
            var res = await _bookRepository.AddBook(book);
        }
        public async Task<BookResponseDto> GetBook(long id)
        {
            var res = await _bookRepository.GetById(id);
            var output = _mapper.Map<BookResponseDto>(res);
            return output;
        }
        public async Task<ICollection<AuthorResponseDto>> GetAuthors(long id)
        {
            var res = await _bookRepository.GetAuthor(id);
            var output = _mapper.Map<ICollection<AuthorResponseDto>>(res);
            return output;

        }

        public async Task DeleteBook(long id)
        {
            var book = await _bookRepository.GetEntity(id);
            if (book == null)
                throw new Exception("Book doesn't exist!");
            await _bookRepository.Delete(book);
        }

        public async Task UpdateBook(BookUpdateDto bookUpdate)
        {
            var res = await _bookRepository.GetById(bookUpdate.Id);

            if (res == null)
                throw new Exception("Book doesn't exist!");

            await _bookRepository.UpdateBook(new Book { Id = bookUpdate.Id, Title = bookUpdate.Title, PageCount = bookUpdate.PageCount });

        }
    }
}
