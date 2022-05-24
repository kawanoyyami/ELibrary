using AutoMapper;
using Common.Dto.Author;
using Domain.Models.Books;

namespace BL.AutoMapperProfiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorCreateDto, Author>();
            CreateMap<Author, AuthorResponseDto>();
            CreateMap<Author, AuthorWithBooksDto>()
                .ForMember(x => x.Books, Y => Y.MapFrom(z => z.Books));
        }
    }
}
