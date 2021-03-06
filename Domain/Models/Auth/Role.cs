using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Auth
{
    public class Role : IdentityRole<long>
    {
        public Role(string roleName) : base(roleName) { }
        public Role() : base() { }
    }
}
