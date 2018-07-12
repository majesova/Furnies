using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEng.Security.Model
{
    public class BitRolePermission
    {
        public Guid RoleId { get; set; }
        public BitRole Role { get; set; }
        public string PermissionKey { get; set; }
        public BitPermission Permission { get; set; }
    }
}
