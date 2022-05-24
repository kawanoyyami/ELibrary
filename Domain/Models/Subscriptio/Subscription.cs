using Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Subscriptio
{
    public class Subscriptionn : EntityBase
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public virtual User? User { get; set; }
        public DateTime StartDateTime { get; set; } = DateTime.Now;
        public DateTime EndDateTime { get; set; } = DateTime.Now;
    }
}
