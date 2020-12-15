using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DormitoryMS.Models
{
    [Table("student")]
    [Description("学生")]
    public class Student
    {
        [Key]
        [Column("student_num")]
        public String studentNum { get; set; }

        [Required]
        [Description("名字")]
        public String name { get; set; }

        [Required]
        [Description("楼号")]
        [Column("building_num")]
        public String buildingNum { get; set; }

        [Required]
        [Description("宿舍号")]
        [Column("dormitory_num")]
        public String dormitoryNum { get; set; }

        [Required]
        [Description("性别")]
        public String sex { get; set; }

        [Required]
        [Description("专业")]
        public String major{ get; set; }

        [Required]
        [Description("联系方式")]
        public String contractInfo { get; set; }
    }
}