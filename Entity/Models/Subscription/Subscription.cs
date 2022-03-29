using Entity.Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Subscription
{
    internal class Subscription : EntityBase
    {
        public long UserId { get; set; }
        public virtual User Customer { get; set; }
        public long? PlanId { get; set; }
        public virtual Plan Plan { get; set; }
        [Required]
        public DateTime SubscriptionStartTimestamp { get; set; }
        [Required]
        public DateTime SubscriptionEndTimestamp { get; set; }
        [NotMapped]
        public bool IsActive { get => DateTime.Compare(SubscriptionStartTimestamp, SubscriptionEndTimestamp) <= 0; }
    }
}
