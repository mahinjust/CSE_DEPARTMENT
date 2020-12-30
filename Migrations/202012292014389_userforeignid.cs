namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userforeignid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.students", "Id", c => c.String(maxLength: 128));
            AddColumn("dbo.teachers", "Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Staffs", "Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.students", "Id");
            CreateIndex("dbo.Staffs", "Id");
            CreateIndex("dbo.teachers", "Id");
            AddForeignKey("dbo.Staffs", "Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.students", "Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.teachers", "Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.teachers", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.students", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Staffs", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.teachers", new[] { "Id" });
            DropIndex("dbo.Staffs", new[] { "Id" });
            DropIndex("dbo.students", new[] { "Id" });
            DropColumn("dbo.Staffs", "Id");
            DropColumn("dbo.teachers", "Id");
            DropColumn("dbo.students", "Id");
        }
    }
}
