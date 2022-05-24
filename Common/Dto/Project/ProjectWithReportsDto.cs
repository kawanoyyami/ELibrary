using Common.Dto.Report;

namespace Common.Dto.Project
{
    public class ProjectWithReportsDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ReportResponseDto> Reports { get; set; }
    }
}
