using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model.Dto.Report;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ReportController : ControllerBase
    {
        private IReportSevice _reportSevice { get; }
        public ReportController(IReportSevice reportSevice)
        {
            _reportSevice = reportSevice;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Getreport(long id)
        {
            var result = await _reportSevice.GetReport(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(long id)
        {
            await _reportSevice.DeleteReport(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReport([FromBody] ReportUpdateDto reportUpdateDto)
        {
            await _reportSevice.UpdateReport(reportUpdateDto);
            return Ok();
        }

        [HttpGet("{id}/project")]
        public async Task<IActionResult> GetProjectName(long id)
        {
            var res = await _reportSevice.GetReportProject(id);

            return Ok(res);
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateReport([FromBody] ReportCreateDto projectCreateDto)
        {
            await _reportSevice.CreateReport(projectCreateDto);

            return Ok();
        }
    }
}
