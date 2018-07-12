using Furnies.Domain.Configuracion;
using System.Data.Entity.ModelConfiguration;

namespace Furnies.Domain.Mappings
{
    public class ConfiguracionMap : EntityTypeConfiguration<ConfiguracionMedicion>
    {
        public ConfiguracionMap()
        {
            ToTable("ConfiguracionesMedicion");
            HasKey(x => x.Clave);
            Property(x => x.Clave).HasMaxLength(20);
            Property(x => x.Nombre).IsRequired().HasMaxLength(250);
            Property(x => x.UnidadMedida).IsRequired().HasMaxLength(30);
        }
    }

    public class ConfiguracionSistemaMap : EntityTypeConfiguration<ConfiguracionSistema>
    {
        public ConfiguracionSistemaMap()
        {
            ToTable("ConfiguracionesSistema");
            HasKey(x => x.Clave);
            Property(x => x.Clave).HasMaxLength(20);
            Property(x => x.Valor).IsRequired().HasMaxLength(30);
            Property(x => x.TipoDato).IsRequired().HasMaxLength(50);
        }
    }



}
