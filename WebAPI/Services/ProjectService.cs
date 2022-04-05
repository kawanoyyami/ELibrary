using AutoMapper;
using Entity.Models;
using Entity.Repository.Interfaces;
using WebAPI.Model.Dto.Project;
using WebAPI.Model.Dto.Report;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class ProjectService : IProjectService
    {
        private IProjectRepository _projectRepository { get; }
        private IMapper _mapper { get; }
        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<ProjectResponseDto> GetProject(long id)
        {
            var res = await _projectRepository.GetById(id);
            var output = _mapper.Map<ProjectResponseDto>(res);
            return output;
        }

        public async Task DeleteProject(long id)
        {
            var res = await _projectRepository.GetById(id);
            await _projectRepository.DeleteProject(id);
        }

        public async Task<ProjectUpdateDto> UpdateProject(ProjectUpdateDto projectUpdate)
        {
            var res = await _projectRepository.GetById(projectUpdate.Id);
            //await _projectRepository.UpdateProject(new Project { Id = projectUpdate.Id, Name = projectUpdate.Name });
            if (res == null)
                throw new Exception("Project doesn't exist!");

            res.Id = projectUpdate.Id;
            res.Name = projectUpdate.Name;
            await _projectRepository.UpdateProject(res);
            return null;
        }

        public async Task CreateProject(ProjectCreateDto projectCreate)
        {
            var project = _mapper.Map<Project>(projectCreate);
            var res = await _projectRepository.CreateProject(project);
        }

        public async Task<ICollection<ReportResponseDto>> GetReports(long id)
        {
            var res = await _projectRepository.GetReports(id);
            var output = _mapper.Map<ICollection<ReportResponseDto>>(res);
            return output;
        }
    }
}
