namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roll : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.activities", "Roll", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.activities", "Roll");
        }
    }
}
