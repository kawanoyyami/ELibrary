using Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Reports
{
    public class Project : EntityBase
    {
        public string? Name { get; set; }
        public virtual long UserId { get; set; }
        public virtual User? User { get; set; }

        public virtual ICollection<Report>? Reports { get; set; }
        public long ReportId { get; set; }
    }
}
