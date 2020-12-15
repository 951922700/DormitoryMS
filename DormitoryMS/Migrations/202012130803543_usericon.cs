namespace DormitoryMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usericon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.user", "icon_path", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.user", "icon_path");
        }
    }
}
