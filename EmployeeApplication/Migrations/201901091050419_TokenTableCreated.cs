namespace EmployeeApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TokenTableCreated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudioTable", "StudioName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.StudioTable", "StudioInformation", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudioTable", "StudioInformation", c => c.String());
            AlterColumn("dbo.StudioTable", "StudioName", c => c.String());
        }
    }
}
