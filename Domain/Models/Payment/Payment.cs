using Domain.Models.Subscriptio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Payment
{
    public class Payment : EntityBase
    {
        public long? SubscriptionId { get; set; }
        public Subscriptionn Subscription { get; set; }
        public long PaymentDetailsId { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
    }
}
