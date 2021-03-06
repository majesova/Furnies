﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEng.Security.Model
{
    public class BitRole : IdentityRole<Guid, BitUserRole>
    {
        public string DisplayName { get; set; }
    }
}
