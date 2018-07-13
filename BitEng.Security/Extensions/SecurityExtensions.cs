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
    public static class SecurityExtensions
    {
        /// <summary>
        /// Verifica si un usuario tiene o no permiso para realizar una acción
        /// </summary>
        /// <param name="context">Contexto de seguridad</param>
        /// <param name="actionKey">Clave de la acción que se desea realizar</param>
        /// <param name="resourceKey">Clave del recurso que se desea acceder</param>
        /// <returns>true/false</returns>
        public static bool HasPermission(this IOwinContext context, string permissionKey)
        {
            var user = (ClaimsIdentity)HttpContext.Current.User.Identity;

            if (!user.IsAuthenticated)
            {
                return false;
            }
            var userId = user.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var securityContext = context.Get<BitSecurityContext>();
            var id = Guid.Parse(userId);
            var repository = new PermissionRepository(securityContext);
            var valid = repository.HasPermission(id, permissionKey);
            return valid;
        }
    }
}
