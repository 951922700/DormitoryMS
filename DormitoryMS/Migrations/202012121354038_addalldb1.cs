namespace DormitoryMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addalldb1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.dormitory",
                c => new
                    {
                        dormitoryNum = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        buildingNum = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        support_num = c.String(unicode: false),
                        resident_num = c.String(unicode: false),
                    })
                .PrimaryKey(t => new { t.dormitoryNum, t.buildingNum });
            
            CreateTable(
                "dbo.equipment_lease",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        student_num = c.String(nullable: false, unicode: false),
                        equ_num = c.Int(nullable: false),
                        equ_name = c.String(nullable: false, unicode: false),
                        lease_date = c.DateTime(nullable: false, precision: 0),
                        return_date = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.feedback",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        content = c.String(nullable: false, unicode: false),
                        date = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.late_return",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        student_num = c.String(nullable: false, unicode: false),
                        reason = c.String(nullable: false, unicode: false),
                        date = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.out_in_check",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        student_num = c.String(nullable: false, unicode: false),
                        item_name = c.String(nullable: false, unicode: false),
                        date = c.DateTime(nullable: false, precision: 0),
                        remark = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.repair",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        building_num = c.String(nullable: false, unicode: false),
                        dormitory_num = c.String(nullable: false, unicode: false),
                        item_num = c.String(nullable: false, unicode: false),
                        reason = c.String(nullable: false, unicode: false),
                        submission_date = c.DateTime(nullable: false, precision: 0),
                        resolution_date = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.staff",
                c => new
                    {
                        staff_num = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, unicode: false),
                        age = c.Int(nullable: false),
                        sex = c.String(nullable: false, unicode: false),
                        position = c.Int(nullable: false),
                        contract_info = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.staff_num);
            
            CreateTable(
                "dbo.student",
                c => new
                    {
                        student_num = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        name = c.String(nullable: false, unicode: false),
                        building_num = c.String(nullable: false, unicode: false),
                        dormitory_num = c.String(nullable: false, unicode: false),
                        sex = c.String(nullable: false, unicode: false),
                        major = c.String(nullable: false, unicode: false),
                        contractInfo = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.student_num);
            
            CreateTable(
                "dbo.visitor_info",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        visitor_name = c.String(nullable: false, unicode: false),
                        visited_people_um = c.String(nullable: false, unicode: false),
                        date = c.String(unicode: false),
                        end_time = c.String(unicode: false),
                        remark = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.we_cost",
                c => new
                    {
                        dormitoryNum = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        buildingNum = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        month = c.DateTime(nullable: false, precision: 0),
                        e_use = c.Decimal(nullable: false, precision: 18, scale: 2),
                        e_cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        w_use = c.Decimal(nullable: false, precision: 18, scale: 2),
                        w_cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.dormitoryNum, t.buildingNum, t.month });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.we_cost");
            DropTable("dbo.visitor_info");
            DropTable("dbo.student");
            DropTable("dbo.staff");
            DropTable("dbo.repair");
            DropTable("dbo.out_in_check");
            DropTable("dbo.late_return");
            DropTable("dbo.feedback");
            DropTable("dbo.equipment_lease");
            DropTable("dbo.dormitory");
        }
    }
}
