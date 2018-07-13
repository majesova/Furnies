using BitEng.Security.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BitEng.Security.Repositories
{
    public class MenuItemRepository
    {
        private BitSecurityContext _context;
        public MenuItemRepository(BitSecurityContext context)
        {
            _context = context;
        }

        public ICollection<BitMenuItem> GetMenuByUsuarioId(Guid id)
        {

            var menuItems = (from r in _context.UserRoles
                             join rolPerm in _context.RolePermissions on r.RoleId equals rolPerm.RoleId
                             join menuItem in _context.MenuItems on rolPerm.PermissionKey equals menuItem.PermissionKey
                             where r.UserId == id
                             orderby menuItem.Order
                             select menuItem.Id).Distinct();

            var items = _context.MenuItems
                            .Include(x => x.Permission)
                            .Include(x => x.Children)
                            .Where(x => menuItems.Contains(x.Id.Value) && x.ParentId == null)
                            .OrderBy(x => x.Order).ToList();

            return items;
        }
    }
}
