using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Domain.Inventario
{
    public class ImagenProducto
    {
        public Guid? Id { get; set; }
        public string MIMEType { get; set; }
        public string FileName { get; set; }
        public bool EsPortada { get; set; }
        public Producto Producto { get; set; }
        public int? ProductoId { get; set; }
    }
}
