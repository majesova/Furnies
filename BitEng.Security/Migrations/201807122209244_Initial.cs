namespace BitEng.Security.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BitPermissions",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 128),
                        FriedlyName = c.String(),
                        GroupedBy = c.String(),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "dbo.BitRolePermissions",
                c => new
                    {
                        PermissionKey = c.String(nullable: false, maxLength: 128),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.PermissionKey, t.RoleId })
                .ForeignKey("dbo.BitPermissions", t => t.PermissionKey, cascadeDelete: true)
                .ForeignKey("dbo.BitRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.PermissionKey)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.BitRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.BitUserRole",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.BitRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.BitUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BitUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        AdditionalInfo = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.BitUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BitUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BitUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.BitUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BitUserRole", "UserId", "dbo.BitUsers");
            DropForeignKey("dbo.BitUserLogins", "UserId", "dbo.BitUsers");
            DropForeignKey("dbo.BitUserClaims", "UserId", "dbo.BitUsers");
            DropForeignKey("dbo.BitRolePermissions", "RoleId", "dbo.BitRoles");
            DropForeignKey("dbo.BitUserRole", "RoleId", "dbo.BitRoles");
            DropForeignKey("dbo.BitRolePermissions", "PermissionKey", "dbo.BitPermissions");
            DropIndex("dbo.BitUserLogins", new[] { "UserId" });
            DropIndex("dbo.BitUserClaims", new[] { "UserId" });
            DropIndex("dbo.BitUsers", "UserNameIndex");
            DropIndex("dbo.BitUserRole", new[] { "UserId" });
            DropIndex("dbo.BitUserRole", new[] { "RoleId" });
            DropIndex("dbo.BitRoles", "RoleNameIndex");
            DropIndex("dbo.BitRolePermissions", new[] { "RoleId" });
            DropIndex("dbo.BitRolePermissions", new[] { "PermissionKey" });
            DropTable("dbo.BitUserLogins");
            DropTable("dbo.BitUserClaims");
            DropTable("dbo.BitUsers");
            DropTable("dbo.BitUserRole");
            DropTable("dbo.BitRoles");
            DropTable("dbo.BitRolePermissions");
            DropTable("dbo.BitPermissions");
        }
    }
}
