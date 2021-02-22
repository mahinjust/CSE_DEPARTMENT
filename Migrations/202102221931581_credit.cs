namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class credit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "Credit", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subjects", "Credit");
        }
    }
}
