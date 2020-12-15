using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DormitoryMS.Models
{
    [Table("out_in_check")]
    [Description("携带贵重物品学生出入登记")]
    public class OutInCheck
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Description("学号")]
        [Column("student_num")]
        public String studentNum { get; set; }

        [Required]
        [Description("贵重物品名字")]
        [Column("item_name")]
        public String itemName { get; set; }

        [Description("离开日期")]
        public DateTime date { get; set; }

        [Description("备注")]
        public String remark { get; set; }
    }
}