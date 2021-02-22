namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namephoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.activities", "Name", c => c.String());
            AddColumn("dbo.students", "Name", c => c.String());
            AddColumn("dbo.students", "Photo", c => c.String());
            AddColumn("dbo.Staffs", "Photo", c => c.String());
            AddColumn("dbo.teachers", "Photo", c => c.String());
            AddColumn("dbo.current_academic", "Name", c => c.String());
            AddColumn("dbo.current_academic", "Roll", c => c.String());
            AddColumn("dbo.results", "Name", c => c.String());
            AddColumn("dbo.previous_academic", "Name", c => c.String());
            DropColumn("dbo.Staffs", "favorite_quote");
            DropColumn("dbo.teachers", "favorite_quote");
        }
        
        public override void Down()
        {
            AddColumn("dbo.teachers", "favorite_quote", c => c.String());
            AddColumn("dbo.Staffs", "favorite_quote", c => c.String());
            DropColumn("dbo.previous_academic", "Name");
            DropColumn("dbo.results", "Name");
            DropColumn("dbo.current_academic", "Roll");
            DropColumn("dbo.current_academic", "Name");
            DropColumn("dbo.teachers", "Photo");
            DropColumn("dbo.Staffs", "Photo");
            DropColumn("dbo.students", "Photo");
            DropColumn("dbo.students", "Name");
            DropColumn("dbo.activities", "Name");
        }
    }
}
