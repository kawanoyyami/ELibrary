using Entity.Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Subscription : EntityBase
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public long PlanId { get; set; }
        public virtual ICollection<Plan>? Plans { get; set; }
        public DateTime SubscriptionStartTimestamp { get; set; }
        public DateTime SubscriptionEndTimestamp { get; set; }
        public bool IsActive { get => DateTime.Compare(SubscriptionStartTimestamp, SubscriptionEndTimestamp) <= 0; }
    }
}
