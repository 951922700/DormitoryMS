namespace DormitoryMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.user",
                c => new
                    {
                        username = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        password = c.String(nullable: false, unicode: false),
                        type = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.username);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.user");
        }
    }
}
