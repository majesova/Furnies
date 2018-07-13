using BitEng.Security.Model;
using BitEng.Security.Repositories;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BitEng.Security.Extensions
{
    public static class OwinMenuExtension
    {
        /// <summary>
        /// Devuelve las opciones de menú que corresponden al usuario según sus permisos
        /// </summary>
        /// <param name="context">Contexto de OWIN</param>
        /// <returns>Colección de permisos</returns>
        public static ICollection<BitMenuItem> GetUserMenu(this IOwinContext context)
        {
            var user = (ClaimsIdentity)HttpContext.Current.User.Identity;
            if (!user.IsAuthenticated)
            {
                return new List<BitMenuItem>();
            }

            var userId = user.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            BitSecurityContext securityContext = context.Get<BitSecurityContext>();
            var id =Guid.Parse( userId);
            var repository = new MenuItemRepository(securityContext);
            return repository.GetMenuByUsuarioId(id);
        }
    }
}
