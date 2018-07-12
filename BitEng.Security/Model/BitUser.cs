
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEng.Security.Model
{
    public class BitUser :IdentityUser<Guid, BitUserLogin,BitUserRole, BitUserClaim>
    {
        public string AdditionalInfo { get; set; }
    }
}
