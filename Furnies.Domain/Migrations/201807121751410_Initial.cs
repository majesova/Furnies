namespace Furnies.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConfiguracionesMedicion",
                c => new
                    {
                        Clave = c.String(nullable: false, maxLength: 20),
                        Nombre = c.String(nullable: false, maxLength: 250),
                        UnidadMedida = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Clave);
            
            CreateTable(
                "dbo.ConfiguracionesSistema",
                c => new
                    {
                        Clave = c.String(nullable: false, maxLength: 20),
                        Valor = c.String(nullable: false, maxLength: 30),
                        TipoDato = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Clave);
            
            CreateTable(
                "dbo.ImagenesProductos",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        MIMEType = c.String(nullable: false),
                        FileName = c.String(nullable: false),
                        EsPortada = c.Boolean(nullable: false),
                        ProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productos", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Clave = c.String(maxLength: 25),
                        Nombre = c.String(maxLength: 100),
                        EsImportado = c.Boolean(nullable: false),
                        Descripcion = c.String(maxLength: 250),
                        esActivo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Version = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedidasProductos",
                c => new
                    {
                        Clave = c.String(nullable: false, maxLength: 128),
                        ProductoId = c.Int(nullable: false),
                        Valor = c.String(maxLength: 20),
                        Orden = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Clave, t.ProductoId })
                .ForeignKey("dbo.Productos", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.PreciosProductos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FormaPago = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productos", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.PresentacionesProductos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Clave = c.String(),
                        Nombre = c.String(maxLength: 250),
                        Orden = c.Int(nullable: false),
                        EsActivo = c.Boolean(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Rgb = c.String(),
                        Hex = c.String(),
                        NombreMaterial = c.String(),
                        Type = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productos", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.ProductoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PresentacionesProductos", "ProductoId", "dbo.Productos");
            DropForeignKey("dbo.PreciosProductos", "ProductoId", "dbo.Productos");
            DropForeignKey("dbo.MedidasProductos", "ProductoId", "dbo.Productos");
            DropForeignKey("dbo.ImagenesProductos", "ProductoId", "dbo.Productos");
            DropIndex("dbo.PresentacionesProductos", new[] { "ProductoId" });
            DropIndex("dbo.PreciosProductos", new[] { "ProductoId" });
            DropIndex("dbo.MedidasProductos", new[] { "ProductoId" });
            DropIndex("dbo.ImagenesProductos", new[] { "ProductoId" });
            DropTable("dbo.PresentacionesProductos");
            DropTable("dbo.PreciosProductos");
            DropTable("dbo.MedidasProductos");
            DropTable("dbo.Productos");
            DropTable("dbo.ImagenesProductos");
            DropTable("dbo.ConfiguracionesSistema");
            DropTable("dbo.ConfiguracionesMedicion");
        }

        
    }
}
