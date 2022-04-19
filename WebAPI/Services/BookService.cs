using AutoMapper;
using Entity.Models;
using WebAPI.Model.Dto.Book;
using WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Common.Exceptions;
using Entity.Repository;

namespace WebAPI.Services
{
    public class BookService : IBookSevice
    {
        private IRepository<Book> _bookRepository { get; }
        private IMapper _mapper { get; }
        public BookService(IRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task CreateBook(BookCreateDto bookCreate)
        {
            var book = _mapper.Map<Book>(bookCreate);
            await _bookRepository.AddAsync(book);
        }
        public async Task<BookResponseDto> GetBook(long id)
        {
            var res = await _bookRepository.GetByIdAsync(id);

            if (res is null)
                throw new NotFoundException("Book doesn't exist!");

            var output = _mapper.Map<BookResponseDto>(res);
            return output;
        }
        public async Task<BookWithAuthorsDto> GetBookWithAuthors(long id)
        {
            var author = await _bookRepository.GetByIdWithIncludeAsync(id, b => b.Authors);

            if (author is null)
                throw new NotFoundException("Book doesn't exist!");

            var output = _mapper.Map<BookWithAuthorsDto>(author);
            return output;
        }
        public async Task DeleteBook(long id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
                throw new NotFoundException("Book doesn't exist!");

            await _bookRepository.Delete(id);
        }

        public async Task<BookUpdateDto> UpdateBook(BookUpdateDto bookUpdate)
        {
            var res = await _bookRepository.GetByIdAsync(bookUpdate.Id);

            if (res == null)
                throw new NotFoundException("Book doesn't exist!");

            //await _bookRepository.UpdateBook(new Book { Title = bookUpdate.Title, PageCount = bookUpdate.PageCount });
            res.Title = bookUpdate.Title;
            res.PageCount = bookUpdate.PageCount;
            await _bookRepository.Update(res);
            return null;
        }


    }
}
