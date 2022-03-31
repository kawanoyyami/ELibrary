using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public byte[]? RowVersion { get; set; }
    }
}
