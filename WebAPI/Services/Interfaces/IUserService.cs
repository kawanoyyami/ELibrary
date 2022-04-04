using WebAPI.Model.Dto.User;
using WebAPI.Model.Mapping;

namespace WebAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> GetUser(long id);
    }
}
