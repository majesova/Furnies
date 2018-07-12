using BitEng.Security.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEng.Security.Managers
{
    public class BitRoleManager : RoleManager<BitRole, Guid>
    {
        public BitRoleManager(IRoleStore<BitRole, Guid> store) : base(store)
        {
        }
    }
}
