using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DormitoryMS.Models
{
    [Table("we_cost")]
    [Description("水电费")]
    public class WaterElectricityCost
    {
        [Key, Column(Order = 1)]
        [Description("楼号")]
       // [Column("dormitory_num")]
        public String dormitoryNum { get; set; }

        [Key, Column(Order = 2)]
        [Description("宿舍号")]
       // [Column("building_num")]
        public String buildingNum { get; set; }

        [Key, Column(Order = 3)]
        [Description("月份")]
        public DateTime month { get; set; }

        [Required]
        [Description("用电量")]
        [Column("e_use")]
        public decimal electricityUse { get; set; }

        [Required]
        [Description("电费")]
        [Column("e_cost")]
        public decimal electricityCost { get; set; }

        [Required]
        [Description("用水量")]
        [Column("w_use")]
        public decimal waterUse { get; set; }

        [Required]
        [Description("水费")]
        [Column("w_cost")]
        public decimal waterCost { get; set; }
    }
}