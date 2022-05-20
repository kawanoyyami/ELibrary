using Entity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Models.Auth
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
        
    }
}
