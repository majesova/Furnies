using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEng.Security.Model
{
    public class BitMenuItem
    {
        public int? Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string PathToResource { get; set; }
        public int? ParentId { get; set; }
        public BitMenuItem Parent { get; set; }

        #region childrens
        public ICollection<BitMenuItem> Children { get; set; }
        #endregion

        #region Related Permission
        public string PermissionKey { get; set; }
        public BitPermission Permission { get; set; }
        #endregion
    }
}
