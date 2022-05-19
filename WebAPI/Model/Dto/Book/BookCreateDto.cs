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

        public bool IsFree { get; set; }

        public string ImagePath { get; set; }
        public string BookName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string AmazonLink { get; set; }

        public IFormFile file { get; set; }
        public IFormFile filebook { get; set; }

    }
}
