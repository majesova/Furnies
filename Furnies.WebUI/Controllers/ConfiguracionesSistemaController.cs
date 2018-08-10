using AutoMapper;
using BitEng.Security.Authorize;
using Furnies.Application;
using Furnies.Domain;
using Furnies.WebUI.Models;
using Furnies.WebUI.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Furnies.WebUI.Controllers
{
    public class ConfiguracionesSistemaController : Controller
    {
        private ConfiguracionSistemaAppService _confService;
        private FurniesContext _furniesContext;
        public ConfiguracionesSistemaController()
        {
            _furniesContext = new FurniesContext();
            _confService = new ConfiguracionSistemaAppService(_furniesContext);
        }

        // GET: ConfiguracionesSistema
        [AuthorizePermission(PermissionKey ="CAN_ACCESS_SYSCONF")]
        public ActionResult Index()
        {
            var results = _confService.GetConfiguraciones().ToList();
            if (!Request.IsAjaxRequest())
            {
                var models = Mapper.Map<List<ConfiguracionSistemaViewModel>>(results);
                return View(models);
            }
            else
            {
                return JsonSettings.BuildJsonResult(results);
            }
        }

        [AuthorizePermission(PermissionKey = "CAN_ACCESS_SYSCONF")]
        [AjaxOnly]
        public ActionResult GetByKey(string key) {
            if (!string.IsNullOrEmpty(key))
            {
                var result = _confService.GetByKey(key);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [AuthorizePermission(PermissionKey = "CAN_MODIFY_SYSCONF")]
        [AjaxOnly]
        public ActionResult SaveConfiguration(SaveConfigurationViewModel model) {
            if (ModelState.IsValid) {
                var updatedObject =_confService.Update(model.Clave, model.Valor);
                SystemSettingsService.UpdateValyeByKeyInCache(model.Clave, model.Valor);
                return Json(updatedObject);
            }
            return Json( ModelState.Select(x=>new { x.Key, x.Value }));
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (_confService != null)
                    _confService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}