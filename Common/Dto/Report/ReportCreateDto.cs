using System.ComponentModel.DataAnnotations;

namespace Common.Dto.Report
{
    public class ReportCreateDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Link { get; set; }

        [Required]
        public long ProjectId { get; set; }
    }
}
