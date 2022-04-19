using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model.Dto.Book
{
    public class BookCreateDto
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public int PageCount { get; set; }
    }
}
