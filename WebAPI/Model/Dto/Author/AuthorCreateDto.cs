using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model.Dto.Author
{
    public class AuthorCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        public string? AreaOfInteresnt { get; set; }
    }
}
