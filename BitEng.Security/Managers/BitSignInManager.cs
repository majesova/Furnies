using BitEng.Security.Model;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BitEng.Security.Managers
{
    public class BitSignInManager : SignInManager<BitUser, Guid>
    {
        public BitSignInManager(BitUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(BitUser user)
        {
            return user.GenerateUserIdentityAsync((BitUserManager)UserManager);
        }

        public static BitSignInManager Create(IdentityFactoryOptions<BitSignInManager> options, IOwinContext context)
        {
            return new BitSignInManager(context.GetUserManager<BitUserManager>(), context.Authentication);
        }
    }

}
