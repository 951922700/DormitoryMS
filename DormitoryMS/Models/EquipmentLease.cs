using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DormitoryMS.Models
{
    [Table("equipment_lease")]
    [Description("宿舍表")]
    public class EquipmentLease
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Description("学号")]
        [Column("student_num")]
        public String studentNum { get; set; }

        [Required]
        [Description("器材数量")]
        [Column("equ_num")]
        public int equNum { get; set; }

        [Required]
        [Description("器材名字")]
        [Column("equ_name")]
        public String equName { get; set; }

        [Required]
        [Description("租赁日期")]
        [Column("lease_date")]
        public DateTime leaseDate { get; set; }

        [Description("归还日期")]
        [Column("return_date")]
        public DateTime? returnDate { get; set; }

        
    }
}