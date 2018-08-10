using Furnies.Application.Usuarios;
using Furnies.Domain;
using Furnies.WebUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Furnies.WebUI.Controllers
{
    public class UsuariosController : Controller
    {
        private UsuarioAppService usuarioService;
        public FurniesContext context = new FurniesContext();
        public UsuariosController()
        {
            usuarioService = new UsuarioAppService(context);
            
        }

        protected override void Dispose(bool disposing)
        {
            usuarioService.Dispose();
            base.Dispose(disposing);
        }
        // GET: Usuarios
        public ActionResult Index(int page=1, Guid? id = null, string email="")
        {
            UsuarioQuery query = new UsuarioQuery();

            if (id != null)
                query.IdIgual(id.Value); //Igual se puede poner directo el expression

            if (string.IsNullOrEmpty(email))
                query.EmailContiene(email); //Igual se puede poner directo el expression

            var pagedUsuarios = usuarioService.GetPaged(query, "Email", page, SystemSettingsService.PageSize);

            return View(pagedUsuarios);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
