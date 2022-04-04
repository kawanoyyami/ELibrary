using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class BookResponseDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
    }
}
