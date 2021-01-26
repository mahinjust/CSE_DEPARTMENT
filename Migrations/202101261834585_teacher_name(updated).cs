namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teacher_nameupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.teachers", "teacher_name", c => c.String());
            DropColumn("dbo.teachers", "teacher__name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.teachers", "teacher__name", c => c.String());
            DropColumn("dbo.teachers", "teacher_name");
        }
    }
}
