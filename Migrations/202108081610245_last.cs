namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class last : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.notices", "File");
            DropColumn("dbo.notices", "Size");
            DropColumn("dbo.notices", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.notices", "Type", c => c.String());
            AddColumn("dbo.notices", "Size", c => c.Long(nullable: false));
            AddColumn("dbo.notices", "File", c => c.String(nullable: false));
        }
    }
}
