using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DormitoryMS.Models
{
    [Table("feedback")]
    [Description("反馈表")]
    public class Feedback
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Description("反馈内容")]
        public String content { get; set; }
        
        [Description("日期")]
        public DateTime date { get; set; }
    }
}