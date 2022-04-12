using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model.Dto.Project;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Authorize(Roles = "admin,FreeUser,PaidUser")]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private IProjectService _projectService { get; }
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(long id)
        {
            var result = await _projectService.GetProject(id);

            return Ok(result);
        }
        [HttpGet("{id}/reports")]
        public async Task<IActionResult> GetProjectReports(long id)
        {
            var res = await _projectService.GetProjectWithReports(id);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteProject(long id)
        {
            await _projectService.DeleteProject(id);

            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateProject(ProjectUpdateDto userModel)
        {
            await _projectService.UpdateProject(userModel);

            return Ok();
        }

        [HttpPost("add")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateProject(ProjectCreateDto projectCreateDto)
        {
            await _projectService.CreateProject(projectCreateDto);
            return Ok();
        }
    }
}
