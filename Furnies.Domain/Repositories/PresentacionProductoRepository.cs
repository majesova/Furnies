using Furnies.Domain.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Domain.Repositories
{

    public class PresentacionProductoRepository : BaseRepository<PresentacionProducto>
    {
        public PresentacionProductoRepository(FurniesContext context) : base(context)
        {

        }
    }

}
