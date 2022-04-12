using AutoMapper;
using Entity.Models;
using WebAPI.Model.Dto.Author;
using Entity.Models.Auth;

namespace WebAPI.Model.Mapping
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
