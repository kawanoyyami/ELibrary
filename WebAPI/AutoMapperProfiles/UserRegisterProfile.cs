using AutoMapper;
using Common.Dto.User;
using Domain.Models.Auth;

namespace BL.AutoMapperProfiles
{
    public class UserRegisterProfile : Profile
    {
        public UserRegisterProfile()
        {
            CreateMap<RegisterUserQueryDto, User>();
            CreateMap<RegisterUserQueryDto, UserResponseDto>();
        }
    }
}
