namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleSelected : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "RoleSelected", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "RoleSelected");
        }
    }
}
