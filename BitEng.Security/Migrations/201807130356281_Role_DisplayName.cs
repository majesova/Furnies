namespace BitEng.Security.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Role_DisplayName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BitRoles", "DisplayName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BitRoles", "DisplayName");
        }
    }
}
