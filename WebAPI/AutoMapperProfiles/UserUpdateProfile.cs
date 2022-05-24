using AutoMapper;
using Common.Dto.User;
using Domain.Models.Auth;

namespace BL.AutoMapperProfiles
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
