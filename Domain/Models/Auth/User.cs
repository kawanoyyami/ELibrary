using Domain.Models;
using Domain.Models.Reports;
using Domain.Models.Subscriptio;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Auth
{
    public class User : IdentityUser<long>, IEntityBase
    {
        public override long Id { get; set; }
        public string? FullName { get; set; }
        public override string? Email { get; set; }
        public DateTime DOB { get; set; }
        public string? RegisterTimestamp { get; set; }
        public virtual ICollection<Project>? Projects { get; set; }
        public virtual ICollection<Subscriptionn>? Subscriptions { get; set; }
        public string? StripeCustomerID { get; set; }

    }
}
