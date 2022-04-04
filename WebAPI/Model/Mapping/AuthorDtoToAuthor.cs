using AutoMapper;
using Entity.Models;
using WebAPI.Model.Dto.Author;

namespace WebAPI.Model.Mapping
{
    public class AuthorDtoToAuthor : Profile
    {
        public AuthorDtoToAuthor()
        {
            CreateMap<AuthorCreateDto, Author>();
            CreateMap<Author, AuthorResponseDto>();
        }
    }
}
