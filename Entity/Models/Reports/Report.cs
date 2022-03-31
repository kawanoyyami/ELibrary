using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Report : EntityBase
    {
        public string? Name { get; set; }
        public string? Link { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid ProjectId { get; set; }
        public Project? Project { get; set; }
    }
}
