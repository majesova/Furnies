using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEng.Security.Repositories
{
    public class PermissionRepository
    {
        private BitSecurityContext _context;
        public PermissionRepository(BitSecurityContext context)
        {
            _context = context;
        }
        public bool HasPermission(Guid userId, string permissionKey)
        {

            var permissions = (from r in _context.UserRoles
                               join rolPerm in _context.RolePermissions on r.RoleId equals rolPerm.RoleId
                               where r.UserId == userId
                               select rolPerm.Permission).Distinct();
            
            return permissions.Any(x => x.Key.ToLower() == permissionKey.ToLower());

        }
    }
}
