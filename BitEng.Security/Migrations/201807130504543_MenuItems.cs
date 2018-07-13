namespace BitEng.Security.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BitMenuItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        Name = c.String(),
                        PathToResource = c.String(),
                        ParentId = c.Int(),
                        PermissionKey = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BitMenuItems", t => t.ParentId)
                .ForeignKey("dbo.BitPermissions", t => t.PermissionKey)
                .Index(t => t.ParentId)
                .Index(t => t.PermissionKey);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BitMenuItems", "PermissionKey", "dbo.BitPermissions");
            DropForeignKey("dbo.BitMenuItems", "ParentId", "dbo.BitMenuItems");
            DropIndex("dbo.BitMenuItems", new[] { "PermissionKey" });
            DropIndex("dbo.BitMenuItems", new[] { "ParentId" });
            DropTable("dbo.BitMenuItems");
        }
    }
}
