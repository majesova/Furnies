namespace Furnies.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Productos", "CreatedById", c => c.Guid(nullable: false));
            AddColumn("dbo.Productos", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Productos", "ModifiedById", c => c.Guid());
            AddColumn("dbo.Productos", "ModifiedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productos", "ModifiedAt");
            DropColumn("dbo.Productos", "ModifiedById");
            DropColumn("dbo.Productos", "CreatedAt");
            DropColumn("dbo.Productos", "CreatedById");
            DropTable("dbo.Usuarios");
        }
    }
}
