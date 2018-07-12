using BitEng.Security.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BitEng.Security.Managers
{
    public class BitRoleStore : RoleStore<BitRole, Guid, BitUserRole>
    {
        public BitRoleStore(DbContext context) : base(context)
        {
        }
    }
}
