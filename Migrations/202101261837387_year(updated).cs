namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yearupdated : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Years", "semester_name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Years", "semester_name", c => c.String());
        }
    }
}
