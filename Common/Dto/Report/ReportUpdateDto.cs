using System.ComponentModel.DataAnnotations;

namespace Common.Dto.Report
{
    public class ReportUpdateDto
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Link { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
