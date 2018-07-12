using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Domain.Inventario
{
    public class MedidaProducto
    {
        public string Clave { get; set; }
        public string Valor { get; set; }
        public int Orden { get; set; }
        public Producto Producto { get; set; }
        public int? ProductoId { get; set; }
    }
}
