namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uploaddownload : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.notices", "File", c => c.String(nullable: false));
            AddColumn("dbo.notices", "Size", c => c.Long(nullable: false));
            AddColumn("dbo.notices", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.notices", "Type");
            DropColumn("dbo.notices", "Size");
            DropColumn("dbo.notices", "File");
        }
    }
}
