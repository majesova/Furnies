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
            if(context.ConfiguracionesMedicion.Where(x=>x.Clave=="HEI").Count()==0)
                context.ConfiguracionesMedicion.Add(new ConfiguracionMedicion { Clave = "HEI", Nombre = "Alto", UnidadMedida = "cm" });
            if (context.ConfiguracionesMedicion.Where(x => x.Clave == "WID").Count() == 0)
                context.ConfiguracionesMedicion.Add(new ConfiguracionMedicion { Clave = "WID", Nombre = "Ancho", UnidadMedida = "cm" });
            if (context.ConfiguracionesMedicion.Where(x => x.Clave == "LON").Count() == 0)
                context.ConfiguracionesMedicion.Add(new ConfiguracionMedicion { Clave = "LON", Nombre = "Largo", UnidadMedida = "cm" });
            if(context.ConfiguracionesSistema.Where(x=>x.Clave == "WelcomeMessage").Count()==0)
                context.ConfiguracionesSistema.Add(new ConfiguracionSistema { Clave = "WelcomeMessage", Valor = "¡Bienvenido a Furnies club!", TipoDato = "System.String" });
            
        }
    }
}
