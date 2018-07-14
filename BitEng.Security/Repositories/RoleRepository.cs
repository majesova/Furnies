using BitEng.Security.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEng.Security.Repositories
{
    public class RoleRepository
    {
        private BitSecurityContext _context;
        public RoleRepository(BitSecurityContext context)
        {
            _context = context;
        }

        public BitRole GetRoleByName(string name) {
            var result = _context.Roles.Where(x => x.Name == name);
            return result.SingleOrDefault();
        }
    }
}
