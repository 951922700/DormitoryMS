using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DormitoryMS.Models
{
    [Table("dormitory")]
    [Description("宿舍表")]
    public class Dormitory
    {
        [Key,Column(Order =1)]
        [Required]
        [Description("宿舍号")]
        public String dormitoryNum { get; set; }

        [Key, Column(Order = 2)]
        [Required]
        [Description("楼号")]
        public String buildingNum { get; set; }

        [Description("可住人数")]
        [DefaultValue(6)]
        [Column("support_num")]
        public int supportNum { get; set; }

        [Description("已住人数")]
        [DefaultValue(0)]
        [Column("resident_num")]
        public int residentNum { get; set; }
    }
}