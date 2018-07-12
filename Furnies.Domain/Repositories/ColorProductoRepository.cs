using Furnies.Domain.Inventario;

namespace Furnies.Domain.Repositories
{

    public class ColorProductoRepository : BaseRepository<ColorProducto>
    {
        public ColorProductoRepository(FurniesContext context) : base(context)
        {

        }
    }

}
