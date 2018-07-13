using BitEng.Security.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Furnies.WebUI.Controllers
{
    public class HomeController : Controller
    {
        [AuthorizePermission(PermissionKey ="CAN_ACCESS_HOME")]
        public ActionResult Index()
        {
            return View();
        }
        [AuthorizePermission(PermissionKey = "CAN_ACCESS_ABOUT")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [AuthorizePermission(PermissionKey = "CAN_ACCESS_CONTACT")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}