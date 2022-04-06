using AutoMapper;
using Entity.Models;
using WebAPI.Model.Dto.Author;

namespace WebAPI.Model.Mapping
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorCreateDto, Author>();
            CreateMap<Author, AuthorResponseDto>();
        }
    }
}
