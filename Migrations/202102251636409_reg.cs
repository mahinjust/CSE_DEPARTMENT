namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.previous_academic", "hsc_reg", c => c.Long(nullable: false));
            AlterColumn("dbo.previous_academic", "ssc_reg", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.previous_academic", "ssc_reg", c => c.Int(nullable: false));
            AlterColumn("dbo.previous_academic", "hsc_reg", c => c.Int(nullable: false));
        }
    }
}
