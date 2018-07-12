namespace Furnies.Domain.Migrations
{
    using Configuracion;
    using Inventario;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Furnies.Domain.FurniesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FurniesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.ConfiguracionesMedicion.Add(new ConfiguracionMedicion { Clave = "HEI", Nombre = "Alto", UnidadMedida = "cm" });
            context.ConfiguracionesMedicion.Add(new ConfiguracionMedicion { Clave = "WID", Nombre = "Ancho", UnidadMedida = "cm" });
            context.ConfiguracionesMedicion.Add(new ConfiguracionMedicion { Clave = "LON", Nombre = "Largo", UnidadMedida = "cm" });
            context.ConfiguracionesSistema.Add(new ConfiguracionSistema { Clave = "WelcomeMessage", Valor = "¡Bienvenido a Furnies club!", TipoDato = "System.String" });
            
        }
    }
}
