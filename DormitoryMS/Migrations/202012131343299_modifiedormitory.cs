namespace DormitoryMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedormitory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.dormitory", "support_num", c => c.Int(nullable: false));
            AlterColumn("dbo.dormitory", "resident_num", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.dormitory", "resident_num", c => c.String(unicode: false));
            AlterColumn("dbo.dormitory", "support_num", c => c.String(unicode: false));
        }
    }
}
