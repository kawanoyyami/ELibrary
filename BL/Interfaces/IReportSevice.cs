using Common.Dto.Report;

namespace BL.Interfaces
{
    public interface IReportSevice
    {
        Task<ReportResponseDto> GetReport(long id);
        Task<ReportWithProjectDto> GetReportWithProjects(long id);
        Task<ReportResponseDto> UpdateReport(ReportUpdateDto reportUpdateDto);
        Task DeleteReport(long id);
        Task CreateReport(ReportCreateDto reportCreateDto);
    }
}
