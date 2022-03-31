using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Plan : EntityBase
    {
        public string? Name { get; set; }

        [Range(0, 1 << 20)]
        public decimal PricePerMonth { get; set; }
        public Guid SubscriptionId { get; set; }
        public virtual Subscription? Subscription { get; set; }
    }
}
