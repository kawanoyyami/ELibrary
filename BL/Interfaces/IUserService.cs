using Common.Dto.User;

namespace BL.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> GetUser(long id);
        Task<UserWithProjectsDto> GetUserWithProjects(long id);
        Task<UserResponseDto> UpdateUser(UserUpdateDto userUpdateDto);
        Task DeleteUser(long id);
    }
}
