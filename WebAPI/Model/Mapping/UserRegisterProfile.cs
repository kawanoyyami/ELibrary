using AutoMapper;
using Entity.Models.Auth;
using WebAPI.Model.Dto.User;

namespace WebAPI.Model.Mapping
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
