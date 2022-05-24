using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Books
{
    public class Author : EntityBase
    {
        public string? FullName { get; set; }
        public DateTime DOB { get; set; }
        public string? AreaOfInteresnt { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}
