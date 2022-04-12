using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class AuthorResponseDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string? AreaOfInteresnt { get; set; }
        public virtual ICollection<BookResponseDto> Books { get; set; }

    }
}
