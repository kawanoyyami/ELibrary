using AutoMapper;
using Entity.Models.Auth;
using WebAPI.Model.Dto.User;

namespace WebAPI.Model.Mapping
{
    public class UserToResponse : Profile
    {
        public UserToResponse()
        {
            CreateMap<User, UserResponseDto>().ForMember(u => u.Phone, mapper => mapper.MapFrom(u => u.PhoneNumber));
        }
    }
}
