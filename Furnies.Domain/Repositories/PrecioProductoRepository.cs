using Furnies.Domain.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Domain.Repositories
{

    public class PrecioProductoRepository : BaseRepository<PrecioProducto>
    {
        public PrecioProductoRepository(FurniesContext context) : base(context)
        {

        }
    }
}

