using WebAPI.Model.Dto.Report;

namespace WebAPI.Model.Dto.Project
{
    public class ProjectWithReportsDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ReportResponseDto> Reports { get; set; }
    }
}
