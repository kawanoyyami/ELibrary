﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Auth
{
    public class UserClaim : IdentityUserClaim<Guid>
    {
    }
}
