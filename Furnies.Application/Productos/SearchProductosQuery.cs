using Furnies.Domain.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Application.Productos
{
    public class SearchProductosQuery : QueryObject<Producto>
    {
        public SearchProductosQuery ClaveContains(string term) {
            And(x => x.Clave.Contains(term));
            return this;
        }
        public SearchProductosQuery NombreContains(string term)
        {
            And(x => x.Nombre.Contains(term));
            return this;
        }
        public SearchProductosQuery DescripcionContains(string term)
        {
            And(x => x.Descripcion.Contains(term));
            return this;
        }
    }
}
