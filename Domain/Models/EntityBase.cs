using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public abstract class EntityBase : IEntityBase
    {
        [Key]
        public long Id { get; set; }
        public byte[]? RowVersion { get; set; }
    }
}
