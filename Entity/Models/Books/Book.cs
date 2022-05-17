using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Book : EntityBase
    {
        public string Title { get; set; }

        public int PageCount { get; set; }

        public ICollection<Author> Authors { get; set; }

        public bool IsFree { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        public string AmazonLink { get; set; }
    }
}
