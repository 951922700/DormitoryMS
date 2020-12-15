using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DormitoryMS.Models
{
    [Table("late_return")]
    [Description("晚归登记")]
    public class LateReturn
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Description("学号")]
        [Column("student_num")]
        public String studentNum { get; set; }

        [Required]
        [Description("原因")]
        public String reason { get; set; }

        [Required]
        [Description("晚归时间")]
        public DateTime date { get; set; }
    }
}