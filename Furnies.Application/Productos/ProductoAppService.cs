using Furnies.Domain;
using Furnies.Domain.Inventario;
using Furnies.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Application.Productos
{
    public class ProductoAppService : IDisposable
    {
        private FurniesContext _context;
        private ProductoRepository _productoRepository;

        public ProductoAppService(FurniesContext context)
        {
            _context = context;
            _productoRepository = new ProductoRepository(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public PagedResult<Producto> GetPaged(IQueryObject<Producto> query, string order, int page = 0, int pageSize = 10) {
            int totalPagesResult = 0;
            int totalRowsResult = 0;

            var queryResult = _productoRepository.QueryPage(query.Query(), out totalPagesResult, out totalRowsResult, order, page, pageSize);
            var result = new PagedResult<Producto>(totalPagesResult, totalRowsResult, queryResult.ToList());
            return result;
        }

        public Producto Find(int id) {
            var includes = new System.Linq.Expressions.Expression<Func<Producto, object>>[] { x => x.Imagenes, x => x.Medidas, x => x.Precios, x => x.Presentaciones };
            var queryResult = _productoRepository.QueryIncluding(x => x.Id == id, includes);
            if (queryResult.Count() > 0) {
                return queryResult.SingleOrDefault();
            }
            return null;
        }


    }
}
