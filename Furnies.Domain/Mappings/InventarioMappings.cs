using Furnies.Domain.Inventario;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Furnies.Domain.Mappings
{
    public class MedidaProductoMap : EntityTypeConfiguration<MedidaProducto>
    {
        public MedidaProductoMap()
        {
            ToTable("MedidasProductos");
            HasKey(x => new { x.Clave, x.ProductoId}); //Clave compuesta
            Property(x => x.Valor).HasMaxLength(20);
            Property(x => x.Orden).IsRequired();
            HasRequired(x => x.Producto).WithMany().HasForeignKey(x => x.ProductoId);
        }
    }

    public class PrecioProductoMap : EntityTypeConfiguration<PrecioProducto>
    {
        public PrecioProductoMap()
        {
            ToTable("PreciosProductos");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FormaPago).IsRequired();
            Property(x => x.Monto).IsRequired();
            HasRequired(x => x.Producto).WithMany().HasForeignKey(x => x.ProductoId);
        }
    }

    public class ImagenProductoMap : EntityTypeConfiguration<ImagenProducto>
    {
        public ImagenProductoMap()
        {
            ToTable("ImagenesProductos");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FileName).IsRequired();
            Property(x => x.MIMEType).IsRequired();
            Property(x => x.EsPortada).IsRequired();
            HasRequired(x => x.Producto).WithMany().HasForeignKey(x => x.ProductoId);
        }
    }


    public class PresentacionProductoMap : EntityTypeConfiguration<PresentacionProducto> {
        public PresentacionProductoMap()
        {
            ToTable("PresentacionesProductos");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nombre).HasMaxLength(250);
            Property(x => x.Orden).IsRequired();
            Property(x => x.EsActivo).IsRequired();
            HasRequired(x => x.Producto).WithMany().HasForeignKey(x => x.ProductoId);
            Map<ColorProducto>(m => m.Requires("Type").HasValue("Col"));
            Map<MaterialProducto>(m => m.Requires("Type").HasValue("Mat"));
        }
    }


    public class ProductoMap : EntityTypeConfiguration<Producto> {
        public ProductoMap()
        {
            ToTable("Productos");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Clave).HasMaxLength(25);
            Property(x => x.esActivo).IsRequired();
            Property(x => x.Nombre).HasMaxLength(100);
            Property(x => x.Descripcion).HasMaxLength(250);
            Property(x => x.EsImportado).IsRequired();
            Property(x => x.Version).IsConcurrencyToken();

            HasMany(x => x.Imagenes).WithRequired(x => x.Producto).HasForeignKey(x => x.ProductoId);
            HasMany(x => x.Precios).WithRequired(x => x.Producto).HasForeignKey(x => x.ProductoId);
            HasMany(x => x.Presentaciones).WithRequired(x => x.Producto).HasForeignKey(x => x.ProductoId);
            HasMany(x => x.Medidas).WithRequired(x => x.Producto).HasForeignKey(x => x.ProductoId);

            Property(x => x.CreatedAt).IsRequired();
            Property(x => x.CreatedById).IsRequired();
        }
    }

    


}
