﻿namespace DormitoryMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reviselease : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.equipment_lease", "return_date", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.equipment_lease", "return_date", c => c.String(unicode: false));
        }
    }
}
