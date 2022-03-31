using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Auth
{
    public class Role : IdentityRole<Guid>
    {
        public Role(string roleName) : base(roleName) { }
        public Role() : base() { }
    }
}
