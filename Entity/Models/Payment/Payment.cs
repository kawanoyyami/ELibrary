using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Payment
{
    public class Payment : EntityBase
    {
        public long? SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
        public long PaymentDetailsId { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
    }
}
