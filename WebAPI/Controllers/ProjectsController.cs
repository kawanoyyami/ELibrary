using Microsoft.AspNetCore.Mvc;
using WebAPI.Model.Dto.Project;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
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

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin,User")] @TO-DO uncomment this
        public async Task<IActionResult> DeleteProject(long id)
        {
            await _projectService.DeleteProject(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject([FromBody] ProjectUpdateDto userModel)
        {
            await _projectService.UpdateProject(userModel);

            return Ok();
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateProject([FromBody] ProjectCreateDto projectCreateDto)
        {
            await _projectService.CreateProject(projectCreateDto);
            return Ok();
        }
    }
}
