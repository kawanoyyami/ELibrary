using BL.Interfaces;
using Common.Dto.Report;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "admin,FreeUser,PaidUser")]
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
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteReport(long id)
        {
            await _reportSevice.DeleteReport(id);
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateReport(ReportUpdateDto reportUpdateDto)
        {
            await _reportSevice.UpdateReport(reportUpdateDto);
            return Ok();
        }

        [HttpGet("{id}/projects")]
        public async Task<IActionResult> GetProjectName(long id)
        {
            var res = await _reportSevice.GetReportWithProjects(id);

            return Ok(res);
        }

        [HttpPost("add")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateReport(ReportCreateDto projectCreateDto)
        {
            await _reportSevice.CreateReport(projectCreateDto);

            return Ok();
        }
    }
}
