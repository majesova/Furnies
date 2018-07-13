using Furnies.Domain.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Domain.Inventario
{
    public class Producto
    {
        public int? Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public bool EsImportado { get; set; }
        public string Descripcion { get; set; }
        public decimal? esActivo { get; set; }

        //Relaciones
        public List<MedidaProducto> Medidas { get; set; }
        public List<ImagenProducto> Imagenes { get; set; }
        public List<PrecioProducto> Precios { get; set; }
        public List<PresentacionProducto> Presentaciones { get; set; }
        //Concurrencia optimista
        public byte[] Version { get; set; }

        public Guid CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? ModifiedAt { get; set; }

    }
}
