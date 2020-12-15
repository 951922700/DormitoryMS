namespace DormitoryMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revisevisitor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.visitor_info", "date", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.visitor_info", "end_time", c => c.DateTime(precision: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.visitor_info", "end_time", c => c.String(unicode: false));
            AlterColumn("dbo.visitor_info", "date", c => c.String(unicode: false));
        }
    }
}
