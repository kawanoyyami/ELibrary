using Common.Dto.User;
using System.Security.Claims;


namespace BL.Interfaces
{
    public interface IAuthService
    {
        Task<LoginUserResponseDto> Login(LoginUserQueryDto loginUserQueryDto);
        Task LogOut();
        Task<UserResponseDto> RegisterUser(RegisterUserQueryDto registerUserQueryDto);
        Task<string> RefreshToken(ClaimsPrincipal userClaims);
    }
}
