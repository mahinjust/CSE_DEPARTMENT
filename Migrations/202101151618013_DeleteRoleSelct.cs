namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteRoleSelct : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "RoleSelect");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "RoleSelect", c => c.String());
        }
    }
}
