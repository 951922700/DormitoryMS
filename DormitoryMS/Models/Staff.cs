using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DormitoryMS.Models
{
    [Table("staff")]
    [Description("员工表")]
    public class Staff
    {
        [Key]
        [Description("员工号")]
        [Column("staff_num")]
        public int staffNum { get; set; }

        [Description("名字")]
        [Required]
        public String name { get; set; }

        [Description("年龄")]
        [Required]
        public int age { get; set; }

        [Description("性别")]
        [Required]
        public String sex { get; set; }

        [Required]
        [Description("职位")]
        public String position { get; set; }

        [Required]
        [Description("联系方式")]
        [Column("contract_info")]
        public String contractInfo { get; set; }
    }
}