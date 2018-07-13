using Furnies.Domain.Configuracion;
using Furnies.Domain.Entities.Accounts;
using Furnies.Domain.Inventario;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Domain
{
    public class FurniesContext : DbContext
    {
        public FurniesContext():base("FurniesConnection")
        {

        }

        public IDbSet<Usuario> Usuarios { get; set; }
        public IDbSet<Producto> Productos { get; set; }
        public IDbSet<ImagenProducto> ImagenesProducto { get; set; }
        public IDbSet<MedidaProducto> MedidasProducto { get; set; }
        public IDbSet<PrecioProducto> PreciosProducto { get; set; }
        public IDbSet<PresentacionProducto> PresentacionesProducto { get; set; }
        public IDbSet<ConfiguracionSistema> ConfiguracionesSistema { get; set; }
        public IDbSet<ConfiguracionMedicion> ConfiguracionesMedicion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(GetType()));
            base.OnModelCreating(modelBuilder);
        }
    }
}
