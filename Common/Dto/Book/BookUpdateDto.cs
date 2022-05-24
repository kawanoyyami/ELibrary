using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Common.Dto.Book
{
    public class BookUpdateDto
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        public bool IsFree { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        public string AmazonLink { get; set; }
        public IFormFile file { get; set; }
    }
}
