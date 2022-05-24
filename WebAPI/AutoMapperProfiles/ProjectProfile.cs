using AutoMapper;
using Common.Dto.Project;
using Domain.Models.Reports;

namespace BL.AutoMapperProfiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectCreateDto, Project>();
            CreateMap<Project, ProjectResponseDto>();
            CreateMap<Project, ProjectWithReportsDto>()
                .ForMember(x => x.Reports, Y => Y.MapFrom(z => z.Reports));
        }
    }
}
