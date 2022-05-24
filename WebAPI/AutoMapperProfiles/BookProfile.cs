using AutoMapper;
using Common.Dto.Book;
using Domain.Models.Books;

namespace BL.AutoMapperProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookCreateDto, Book>();
            CreateMap<BookUpdateDto, Book>();
            CreateMap<Book, BookUpdateDto>();
            CreateMap<Book, BookResponseDto>();
            CreateMap<BookUpdateDto, Book>();
            CreateMap<Book, BookWithAuthorsDto>()
                .ForMember(x => x.Authors, Y => Y.MapFrom(z => z.Authors));
        }
    }
}
