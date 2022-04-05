using WebAPI.Model.Dto.Project;
using WebAPI.Model.Dto.Report;

namespace WebAPI.Services.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectResponseDto> GetProject(long id);
        Task DeleteProject(long id);
        Task<ICollection<ReportResponseDto>> GetReports(long id);
        Task<ProjectUpdateDto> UpdateProject(ProjectUpdateDto projectUpdate);
        Task CreateProject(ProjectCreateDto projectCreate);
    }
}
