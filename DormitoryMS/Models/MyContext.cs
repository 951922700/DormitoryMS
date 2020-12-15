using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DormitoryMS.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MyContext : DbContext
    {
        public MyContext()
            : base("name=MyContext")
        {
        }
        public  DbSet<User> Users { get; set; }
        public DbSet<Dormitory> Dormitories { get; set; }
        public DbSet<EquipmentLease> EquipmentLeases { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<LateReturn> LateReturns { get; set; }

        public DbSet<OutInCheck> OutInChecks { get; set; }

        public DbSet<Repair> Repairs { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<VisitorInfo> VisitorInfos { get; set; }

        public DbSet<WaterElectricityCost> WaterElectricityCosts { get; set; }

    }
}