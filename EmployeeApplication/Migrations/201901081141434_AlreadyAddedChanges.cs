namespace EmployeeApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlreadyAddedChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "EmployeeName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Employees", "EmployeeStudio", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Employees", "EmployeeUserName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Employees", "EmployeePassword", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "EmployeePassword", c => c.String());
            AlterColumn("dbo.Employees", "EmployeeUserName", c => c.String());
            AlterColumn("dbo.Employees", "EmployeeStudio", c => c.String());
            AlterColumn("dbo.Employees", "EmployeeName", c => c.String());
        }
    }
}
