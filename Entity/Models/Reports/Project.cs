using Entity.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Reports
{
    internal class Project : EntityBase
    {
        public string Name { get; set; }
        public virtual long UserId { get; set; }
        public virtual User User { get; set; }
    }
}
