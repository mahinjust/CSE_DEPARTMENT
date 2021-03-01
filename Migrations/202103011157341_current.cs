namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class current : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.current_academic", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.current_academic", "Name", c => c.String(nullable: false));
        }
    }
}
