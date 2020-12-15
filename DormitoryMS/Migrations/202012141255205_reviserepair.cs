namespace DormitoryMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reviserepair : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.repair", "item_name", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.repair", "submission_date", c => c.DateTime(precision: 0));
            AlterColumn("dbo.repair", "resolution_date", c => c.DateTime(precision: 0));
            DropColumn("dbo.repair", "item_num");
        }
        
        public override void Down()
        {
            AddColumn("dbo.repair", "item_num", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.repair", "resolution_date", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.repair", "submission_date", c => c.DateTime(nullable: false, precision: 0));
            DropColumn("dbo.repair", "item_name");
        }
    }
}
