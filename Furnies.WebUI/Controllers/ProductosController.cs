using AutoMapper;
using Furnies.Application.Productos;
using Furnies.Domain;
using Furnies.Domain.Inventario;
using Furnies.WebUI.Models;
using Furnies.WebUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Furnies.WebUI.Controllers
{
    public class ProductosController : Controller
    {
        private FurniesContext _context;
        private ProductoAppService _productoService;
        private SystemSettingsService _systemSettings;
        public ProductosController()
        {
            _context = new FurniesContext();
            _productoService = new ProductoAppService(_context);
            _systemSettings = new SystemSettingsService();
        }
        // GET: Productos
        public ActionResult Index( string filter, int page=1, string order ="Nombre")
        {
            SearchProductosQuery query = new SearchProductosQuery();
            query
                .ClaveContains(filter)
                .DescripcionContains(filter)
                .NombreContains(filter);
            var serviceResults = _productoService.GetPaged(query, order, page, SystemSettingsService.PageSize);
            var modelResult = new ProductoListViewModel(page, SystemSettingsService.PageSize,serviceResults.TotalRows, serviceResults.TotalPages);
            modelResult.Items = Mapper.Map<List<ProductoViewModel>>(serviceResults.Result);
            modelResult.SortedBy = order;
            modelResult.FilteredBy = filter;
            return View(modelResult);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(_productoService!=null)
                    _productoService.Dispose();
            }
            
            base.Dispose(disposing);
        }
    }
}