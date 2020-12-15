using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DormitoryMS.Models
{
    [Table("repair")]
    [Description("报修")]
    public class Repair
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Description("楼号")]
        [Column("building_num")]
        public String buildingNum { get; set; }

        [Required]
        [Description("宿舍号")]
        [Column("dormitory_num")]
        public String dormitoryNum { get; set; }

        [Required]
        [Description("物品名")]
        [Column("item_name")]
        public String itemName { get; set; }

        [Required]
        [Description("原因")]
        public String reason { get; set; }

        
        [Description("提交日期")]
        [Column("submission_date")]
        public DateTime? submissionDate { get; set; }

        
        [Description("解决日期")]
        [Column("resolution_date")]
        public DateTime? resolutionDate { get; set; }
    }
}