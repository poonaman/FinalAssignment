namespace EmployeeApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        EmployeeSalary = c.Single(nullable: false),
                        EmployeeAge = c.Int(nullable: false),
                        EmployeeStudio = c.String(),
                        EmployeeUserName = c.String(),
                        EmployeePassword = c.String(),
                        Studio_StudioId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.StudioTable", t => t.Studio_StudioId)
                .Index(t => t.Studio_StudioId);
            
            CreateTable(
                "dbo.StudioTable",
                c => new
                    {
                        StudioId = c.Int(nullable: false, identity: true),
                        StudioName = c.String(),
                        StudioInformation = c.String(),
                    })
                .PrimaryKey(t => t.StudioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Studio_StudioId", "dbo.StudioTable");
            DropIndex("dbo.Employees", new[] { "Studio_StudioId" });
            DropTable("dbo.StudioTable");
            DropTable("dbo.Employees");
        }
    }
}
