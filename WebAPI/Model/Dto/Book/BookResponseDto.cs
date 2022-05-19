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

        public bool IsFree { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        public string AmazonLink { get; set; }
        public string BookName { get; set; }
    }
}
