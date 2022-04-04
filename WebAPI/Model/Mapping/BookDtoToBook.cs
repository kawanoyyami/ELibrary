using AutoMapper;
using Entity.Models;
using WebAPI.Model.Dto.Book;

namespace WebAPI.Model
{
    public class BookDtoToBook : Profile
    {
        public BookDtoToBook()
        {
            CreateMap<BookCreateDto, Book>();
            CreateMap<Book, BookResponseDto>();
            CreateMap<BookUpdateDto, Book>();
        }
    }
}
