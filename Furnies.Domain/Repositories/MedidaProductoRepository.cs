using Furnies.Domain.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Domain.Repositories
{

    public class MedidaProductoRepository : BaseRepository<MedidaProducto>
    {
        public MedidaProductoRepository(FurniesContext context) : base(context)
        {

        }
    }

}
