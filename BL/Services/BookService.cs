using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Common.Exceptions;
using Common.Models.PagedRequestModels;
using BL.Interfaces;
using DataAccess.Repository.Interfaces;
using Domain.Models.Books;
using Common.Dto.Book;
using Microsoft.AspNetCore.Http;

namespace BL.Services
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
            if (bookCreate.file == null)
            {
                throw new NotFoundException("There are no photos to upload.");
            }

            var bookname = UploadBook(bookCreate.filebook);
            bookCreate.BookName = bookname.Result.ToString();

            var imageName = UploadPicture(bookCreate.file);
            bookCreate.ImagePath = imageName.Result.ToString();


            var book = _mapper.Map<Book>(bookCreate);
            await _bookRepository.AddAsync(book);
        }
        public async Task<BookResponseDto> GetBook(long id)
        {
            if (id <= 0)
                throw new BadRequestException("Id is not valid number!");

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
                throw new ValueOutOfRangeException($"Book could not be deleted because book with id: {id} not exist in database!");

            await _bookRepository.Delete(id);
        }

        public async Task<BookUpdateDto> UpdateBook(BookUpdateDto bookUpdate)
        {
            var res = await _bookRepository.GetByIdAsync(bookUpdate.Id);

            if (res == null)
                throw new ValueOutOfRangeException($"Book could not be updated because book with id: {bookUpdate.Id} not exist in database!");

            if (bookUpdate.file == null)
                throw new NotFoundException("There are no photos to upload.");


            var imageName = UploadPicture(bookUpdate.file);
            bookUpdate.ImagePath = imageName.Result.ToString();
            _mapper.Map(bookUpdate, res);

            await _bookRepository.Update(res);
            return null;
        }

        public async Task<PaginatedResult<BookResponseDto>> GetPagedBooks(PagedRequest pagedRequest)
        {
            var pagedBooks = await _bookRepository.GetPagedData<Book, BookResponseDto>(pagedRequest);
            return pagedBooks;
        }

        public async Task<List<BookResponseDto>> GetAllBoks()
        {
            var listBooks = await _bookRepository.ListAsync();

            var result = _mapper.Map<List<BookResponseDto>>(listBooks);

            return result;
        }
        private async Task<object> UploadPicture(IFormFile file)
        {

            //@TODO refactor this, add validation
            string imageName = new string(Path.GetFileNameWithoutExtension(file.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(file.FileName);

            var path = Path.Combine(Directory.GetCurrentDirectory() + @"\Resources\BookImages", imageName);

            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);

            return imageName;
        }

        private async Task<object> UploadBook(IFormFile file)
        {

            //@TODO refactor this, add validation
            string imageName = new string(Path.GetFileNameWithoutExtension(file.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(file.FileName);

            var path = Path.Combine(Directory.GetCurrentDirectory() + @"\Resources\Bookspdf", imageName);

            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);

            return imageName;
        }

    }
}
