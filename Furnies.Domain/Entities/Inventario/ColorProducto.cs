using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Domain.Inventario
{
    public class ColorProducto : PresentacionProducto
    {
        public string Rgb { get; set; }
        public string Hex { get; set; }
    }
}
