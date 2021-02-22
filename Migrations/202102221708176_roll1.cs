namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roll1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.current_academic", "Roll", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.current_academic", "Roll", c => c.String());
        }
    }
}
