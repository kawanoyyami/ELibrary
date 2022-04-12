using AutoMapper;
using Common.Exceptions;
using Entity.Models;
using Entity.Repository;
using Entity.Repository.Interfaces;
using WebAPI.Model.Dto.Project;
using WebAPI.Model.Dto.Report;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class ProjectService : IProjectService
    {
        private IRepository<Project> _projectRepository { get; }
        private IMapper _mapper { get; }
        public ProjectService(IRepository<Project> projectRepository, IMapper mapper, IRepository<Project> genericRepository)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<ProjectResponseDto> GetProject(long id)
        {
            var res = await _projectRepository.GetByIdAsync(id);
            var output = _mapper.Map<ProjectResponseDto>(res);
            return output;
        }

        public async Task DeleteProject(long id)
        {
            var res = await _projectRepository.GetByIdAsync(id);
            if (res == null)
                throw new NotFoundException("Project doesn't exist!");
            await _projectRepository.Delete(id);
        }

        public async Task<ProjectUpdateDto> UpdateProject(ProjectUpdateDto projectUpdate)
        {
            var res = await _projectRepository.GetByIdAsync(projectUpdate.Id);

            //await _projectRepository.UpdateProject(new Project { Id = projectUpdate.Id, Name = projectUpdate.Name });
            //@TO-DO refactor this 
            if (res == null)
                throw new NotFoundException("Project doesn't exist!");

            res.Id = projectUpdate.Id;
            res.Name = projectUpdate.Name;
            await _projectRepository.Update(res);
            return null;
        }

        public async Task CreateProject(ProjectCreateDto projectCreate)
        {
            var project = _mapper.Map<Project>(projectCreate);
            await _projectRepository.AddAsync(project);
        }

        public async Task<ProjectWithReportsDto> GetProjectWithReports(long id)
        {
            var report = await _projectRepository.GetByIdWithIncludeAsync(id, b => b.Reports);
            var output = _mapper.Map<ProjectWithReportsDto>(report);
            return output;
        }
    }
}
