using DormitoryMS.Models;
using DormitoryMS.Models.result;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DormitoryMS.Controllers
{
    public class UsersController : Controller
    {

        public MyContext db=new MyContext();
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        /**
         * 登录功能
         * https://localhost:44376/users/login?username=2018071027&password=943033940&type=学生
         */
        [HttpGet]
        public JsonResult login(User user) {
            if (ModelState.IsValid)
            {
                var u = db.Users.Find(user.username);
                //if(user)
                /*if (u == null) {
                    var error = "账号密码不匹配，请检查";
                }
                    return Json()*/
                //Console.WriteLine("方法执行" + user.password);
                if (u == null)
                    return Json(ResultMap.errorMsg("用户不存在"), JsonRequestBehavior.AllowGet);
                else if (u.password != user.password&&u.type==user.type)
                    return Json(ResultMap.errorMsg("密码错误或者类型错误"), JsonRequestBehavior.AllowGet);
                else
                    return Json(ResultMap.OK(), JsonRequestBehavior.AllowGet);
            }
            else 
            {
                StringBuilder errMsg = new StringBuilder();
                //获取错误信息并返回
                var values = ModelState.Values;

                foreach (var item in values) {
                    foreach (var error in item.Errors) {
                        errMsg.Append(error.ErrorMessage + " ");
                    }
                }
                //ResultMap.errorMsg(errMsg.ToString())
                return Json(ResultMap.errorMsg(errMsg.ToString()), JsonRequestBehavior.AllowGet);
            }
           
        }

        /**
         * 上传文件  需要传递username参数
         * 若上传成功返回路径
         * https://localhost:44376/users/Upload?file
         */
        [HttpPost]
        public JsonResult Upload(HttpPostedFileBase file,String username) 
        {
            if (file == null) {
                return Json(ResultMap.errorMsg("没有上传文件"), JsonRequestBehavior.AllowGet);
            }

            var fileName = file.FileName;
            var filePath = Path.Combine(Server.MapPath("~/upload"), fileName);

            try
            {
                file.SaveAs(filePath);
                //查询该用户并更新iconpath字段并保存修改
                User user = db.Users.Find(username);
                user.iconPath = "../upload/" + fileName;
                db.SaveChanges();
            }
            catch (Exception e) 
            {
                return Json(ResultMap.errorMsg("服务器异常"), JsonRequestBehavior.AllowGet);
            }
            return Json(ResultMap.OK("../upload/" + fileName), JsonRequestBehavior.AllowGet);

        }

        /**
         * 重置账号密码为对应学号
         * https://localhost:44376/users/reset?studentNum=666666
         */
        [HttpPost]
        public JsonResult reset(String studentNum) 
        {
            User user = db.Users.Find(studentNum);
            if (user == null)
                return Json(ResultMap.errorMsg("没有这个用户"), JsonRequestBehavior.AllowGet);
            user.password = studentNum;
            db.SaveChanges();
            return Json(ResultMap.OK(), JsonRequestBehavior.AllowGet);
        }
    }
}