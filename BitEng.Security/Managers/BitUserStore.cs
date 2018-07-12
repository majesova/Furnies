using BitEng.Security.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BitEng.Security.Stores
{
    public class BitUserStore : UserStore<BitUser, BitRole, Guid, BitUserLogin, BitUserRole, BitUserClaim>
    {
        public BitUserStore(DbContext context) : base(context)
        {
        }
    }
}
