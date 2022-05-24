using Common.Dto.Project;

namespace Common.Dto.Report
{
    public class ReportWithProjectDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ProjectResponseDto Project { get; set; }
    }
}
