using AutoMapper;
using Entity.Models.Auth;
using WebAPI.Model.Dto.User;

namespace WebAPI.Model.Mapping
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
