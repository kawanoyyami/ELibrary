using WebAPI.Model.Dto.Project;

namespace WebAPI.Services.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectResponseDto> GetProject(long id);
        Task DeleteProject(long id);
        //Task<ICollection<ReportResponseDto>> GetReports(long id);

        Task UpdateProject(ProjectUpdateDto projectUpdate);

        Task CreateProject(ProjectCreateDto projectCreate);
    }
}
