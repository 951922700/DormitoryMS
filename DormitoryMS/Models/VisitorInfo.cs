using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DormitoryMS.Models
{
    [Table("visitor_info")]
    [Description("来访人员信息")]
    public class VisitorInfo
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Description("来访者信息")]
        [Column("visitor_name")]
        public String visitorName { get; set; }

        [Required]
        [Description("被访人学号")]
        [Column("visited_people_um")]
        public String visitedPeopleNum { get; set; }

        [Description("来访日期")]
        public DateTime date { get; set; }

        [Description("结束时间")]
        [Column("end_time")]
        public DateTime? endTime { get; set; }

        [Description("备注")]
        public String remark { get; set; }
    }
}