using BitEng.Security.Model;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEng.Security.Providers
{
    public class BitDataProtectorTokenProvider : DataProtectorTokenProvider<BitUser, Guid>
    {
        public BitDataProtectorTokenProvider(IDataProtector protector) : base(protector)
        {
        }
    }
}
