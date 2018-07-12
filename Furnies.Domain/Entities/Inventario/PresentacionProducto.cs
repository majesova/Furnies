using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Domain.Inventario
{
    public abstract class PresentacionProducto
    {
        public int? Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public int Orden { get; set; }
        public bool EsActivo { get; set; }
        public Producto Producto { get; set; }
        public int? ProductoId { get; set; }
    }
}
