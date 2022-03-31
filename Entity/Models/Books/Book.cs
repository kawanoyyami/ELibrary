using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Book : EntityBase
    {
        public string? Title { get; set; }
        public int PageCount { get; set; }
        public virtual ICollection<Author>? Authors { get; set; }
    }
}
