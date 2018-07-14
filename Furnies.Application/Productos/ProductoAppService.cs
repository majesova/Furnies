using Furnies.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Application.Productos
{
    public class ProductoAppService : IDisposable
    {
        private FurniesContext _context;
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
