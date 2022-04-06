using WebAPI.Model.Dto.User;

namespace WebAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginUserResponseDto> Login(LoginUserQueryDto loginUserQueryDto);
        Task LogOut();
        Task<UserResponseDto> RegisterUser(RegisterUserQueryDto registerUserQueryDto);
    }
}
