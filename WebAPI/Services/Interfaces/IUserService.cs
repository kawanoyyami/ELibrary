using WebAPI.Model.Dto.Project;
using WebAPI.Model.Dto.Report;
using WebAPI.Model.Dto.User;
using WebAPI.Model.Mapping;

namespace WebAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> GetUser(long id);
        Task<UserResponseDto> UpdateUser(UserUpdateDto userUpdateDto);
        Task DeleteUser(long id);
        Task<ICollection<ProjectResponseDto>> GetUserProject(long id);
        Task<ICollection<ReportResponseDto>> GetUserReport(long id);
    }
}
