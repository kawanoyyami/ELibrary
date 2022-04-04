using AutoMapper;
using Entity.Models;
using WebAPI.Model.Dto.Project;

namespace WebAPI.Model.Mapping
{
    public class ProjectsToDto : Profile
    {
        public ProjectsToDto()
        {
            CreateMap<ProjectCreateDto, Project>();

            CreateMap<Project, ProjectResponseDto>();
        }
    }
}
