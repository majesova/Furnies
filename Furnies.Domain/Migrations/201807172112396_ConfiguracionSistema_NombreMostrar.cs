namespace Furnies.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfiguracionSistema_NombreMostrar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConfiguracionesSistema", "NombreMostrar", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ConfiguracionesSistema", "NombreMostrar");
        }
    }
}
