namespace WebAPI.Model.Dto.Report
{
    public class ReportCreateDto
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public long ProjectId { get; set; }
    }
}
