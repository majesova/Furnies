using BitEng.Security.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEng.Security.Managers
{
    public class BitUserValidator : UserValidator<BitUser, Guid>
    {
        public BitUserValidator(UserManager<BitUser, Guid> manager) : base(manager)
        {
        }
    }
}
