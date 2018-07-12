using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Domain.Inventario
{
    public class PrecioProducto
    {
        public int? Id { get; set; }
        public decimal Monto { get; set; }
        public FormaPago FormaPago { get; set; }
        public Producto Producto { get; set; }
        public int? ProductoId { get; set; }
    }
}
