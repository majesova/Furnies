using Furnies.Domain.Inventario;
using Furnies.WebUI.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Furnies.WebUI.Models
{
    public class ProductoViewModel {
        public int? Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public bool EsImportado { get; set; }
        public string Descripcion { get; set; }
        public decimal? esActivo { get; set; }
    }
    public class ProductoListViewModel: PagedList<ProductoViewModel>
    {
        public ProductoListViewModel(int page, int pageSize, int totalRows, int totalPages)
        {
            Page = page;
            TotalRows = totalRows;
            PageSize = pageSize;
            TotalPages = totalPages;
        }   
        public string SortedBy { get; set; }
        public string FilteredBy { get; set; }
    }
}