using AutoMapper;
using Common.Dto.User;
using Domain.Models.Auth;

namespace BL.AutoMapperProfiles
{
    public class UserResponseProfile : Profile
    {
        public UserResponseProfile()
        {
            CreateMap<User, UserResponseDto>().ForMember(u => u.Phone, mapper => mapper.MapFrom(u => u.PhoneNumber));
            CreateMap<User, UserWithProjectsDto>().ForMember(u => u.Projects, mapper => mapper.MapFrom(u => u.Projects));
        }
    }
}
