using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DormitoryMS.Models
{
    [Table("user")]
    [Description("用户表")]
    public class User
    {
        [Key]
        [Description("登录名,学生用学号表示，管理员后台创建账号")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "登录名为空")]
        //登录名 主键
        public String username { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="密码为空")]
        [Description("密码")]
        //密码
        public String password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "用户类型为空")]
        [Description("用户类型")]
        //类型  学生or管理员
        public String type { get; set; }
        
        [Column("icon_path")]
        [DefaultValue("~/favicon.ico")]
        public String iconPath { get; set; }

    }
}