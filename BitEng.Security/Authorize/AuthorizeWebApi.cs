using BitEng.Security.Repositories;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;

namespace BitEng.Security.Authorize
{
    public class AuthorizePermissionApiAttribute : System.Web.Http.AuthorizeAttribute
    {
        public string PermissionKey { get; set; }

        HttpActionContext context;

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            context = actionContext;
            base.OnAuthorization(actionContext);
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var user = (ClaimsIdentity)HttpContext.Current.User.Identity;
            if (!user.IsAuthenticated)
            {
                HandleUnauthorizedRequest(actionContext);
                return false;
            }
            var userId = user.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            BitSecurityContext securityContext = HttpContext.Current.GetOwinContext().Get<BitSecurityContext>();
            var id = Guid.Parse(userId);
            var repository = new PermissionRepository(securityContext);
            var valid = repository.HasPermission(id, PermissionKey);
            if (!valid)
            {
                HandleUnauthorizedRequest(actionContext);
                return false;
            }

            return base.IsAuthorized(actionContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            actionContext.Response = response;
        }
    }
}
