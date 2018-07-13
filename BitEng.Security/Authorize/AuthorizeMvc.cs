using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using BitEng.Security.Repositories;

namespace BitEng.Security.Authorize
{
    public class AuthorizePermissionAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// Clave de la acción que se quiere realizar
        /// </summary>
        public string PermissionKey { get; set; }
       
        /// <summary>
        /// Contexto asociado a la seguridad
        /// </summary>
        private AuthorizationContext _currentContext;
        /// <summary>
        /// Se ejecuta cuando se atiende una autorización
        /// </summary>
        /// <param name="filterContext">Contexto de autorización</param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            _currentContext = filterContext;
            base.OnAuthorization(filterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = (ClaimsIdentity)HttpContext.Current.User.Identity;
            if (!user.IsAuthenticated)
            {
                return false;
            }
            var userId = user.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            BitSecurityContext securityContext = httpContext.GetOwinContext().Get<BitSecurityContext>();
            var id = Guid.Parse(userId);
            var repository = new PermissionRepository(securityContext);
            var valid = repository.HasPermission(id, PermissionKey);
            return valid;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }


    }
}
