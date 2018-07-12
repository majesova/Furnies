using Furnies.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            FurniesContext ctx = new FurniesContext();
            var mediciones = ctx.ConfiguracionesMedicion;
            Console.WriteLine(mediciones.Count());
            Console.ReadKey();
        }
    }
}
