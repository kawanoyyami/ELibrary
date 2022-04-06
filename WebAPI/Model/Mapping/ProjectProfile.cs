using AutoMapper;
using Entity.Models;
using WebAPI.Model.Dto.Project;

namespace WebAPI.Model.Mapping
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectCreateDto, Project>();
            CreateMap<Project, ProjectResponseDto>();
        }
    }
}
