using AutoMapper;
using Entity.Models.Auth;
using WebAPI.Model.Dto.User;

namespace WebAPI.Model.AutoMapperProfiles
{
    public class UserUpdateProfile : Profile
    {
        public UserUpdateProfile()
        {
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserUpdateDto>();
        }
    }
}
