using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Books
{
    internal class Book : EntityBase
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string Authors { get; set; }
    }
}
