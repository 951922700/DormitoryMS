namespace DormitoryMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revisestaff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.staff", "position", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.staff", "position", c => c.Int(nullable: false));
        }
    }
}
