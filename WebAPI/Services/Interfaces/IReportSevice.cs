using WebAPI.Model.Dto.Project;
using WebAPI.Model.Dto.Report;
using WebAPI.Model.Dto.User;

namespace WebAPI.Services.Interfaces
{
    public interface IReportSevice
    {
        Task<ReportResponseDto> GetReport(long id);
        Task<ReportResponseDto> UpdateReport(ReportUpdateDto reportUpdateDto);
        Task DeleteReport (long id);
        Task<UserResponseDto> GetReportUser(long id);
        Task CreateReport(ReportCreateDto reportCreateDto);
        Task<ProjectResponseDto> GetReportProject(long id);
    }
}
