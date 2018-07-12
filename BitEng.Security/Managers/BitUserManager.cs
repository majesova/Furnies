using BitEng.Security.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEng.Security.Managers
{
    public class BitUserManager : UserManager<BitUser, Guid>
    {
        public BitUserManager(IUserStore<BitUser, Guid> store) : base(store)
        {
        }

        public static BitUserManager Create(IdentityFactoryOptions<BitUserManager> options, IOwinContext context)
        {

        }
    }
}
