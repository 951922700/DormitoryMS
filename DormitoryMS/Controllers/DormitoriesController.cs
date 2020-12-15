using DormitoryMS.Models;
using DormitoryMS.Models.result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DormitoryMS.Controllers
{
    //@Path /dormitories
    public class DormitoriesController : Controller
    {
        public MyContext db = new MyContext();
        // GET: Dormitories
        public ActionResult Index()
        {
            return View();
        }


        /**
         * 获取所有宿舍
         */
        [HttpGet]
        public JsonResult getAll() {
            var ds = from item in db.Dormitories
                     where true //此处可以写条件表达式
                     orderby item.buildingNum descending
                     select item;
            return Json(ResultMap.OK(ds.ToList()), JsonRequestBehavior.AllowGet);
        }

        /**
         * 换宿舍  需要新宿舍号 新楼号
         * dormitoryNum  buildingNum
         * https://localhost:44376/dormitories/update?studentNum=2018071027&buildingNum=K&dormitoryNum=521
         */
        [HttpPost]
        public JsonResult update(String studentNum,Dormitory dormitory) {
            //获取学生信息  得到原本宿舍信息
            Student student = db.Students.Find(studentNum);
            if(student==null) 
                return Json(ResultMap.errorMsg("查无此人"), JsonRequestBehavior.AllowGet);
            try
            {
                //保存学生原本宿舍信息
                string buildingNum = student.buildingNum;
                string dormitoryNum = student.dormitoryNum;
                //修改学生信息
                student.buildingNum = dormitory.buildingNum;
                student.dormitoryNum = dormitory.dormitoryNum;
                //修改原本宿舍和新宿舍 已住人数   因为mdoel定义时  dormitorynum为1所以参数放前面
                Dormitory old=db.Dormitories.Find(dormitoryNum, buildingNum);
                old.residentNum = old.residentNum - 1;
                Dormitory newd = db.Dormitories.Find(dormitory.dormitoryNum, dormitory.buildingNum);
                newd.residentNum = newd.residentNum + 1;
                //保存修改
                db.SaveChanges();
            }
            catch (Exception e) 
            {
                return Json(ResultMap.errorMsg("数据库错误"), JsonRequestBehavior.AllowGet);
            }
            return Json(ResultMap.OK(), JsonRequestBehavior.AllowGet);
        }

        /**
         * 退宿舍 宿舍人数减1并且删除学生记录，以及用户记录
         * https://localhost:44376/dormitories/quit?studentNum=222
         */
        [HttpPost]
        public JsonResult quit(String studentNum) 
        {
            try
            {
                //得到学生对象
                Student student = db.Students.Find(studentNum);
                User user = db.Users.Find(studentNum);//学生学号为登录名
                //得到对应宿舍对象
                Dormitory dormitory = db.Dormitories.Find(student.dormitoryNum, student.buildingNum);
                dormitory.residentNum = dormitory.residentNum - 1;
                //删除学生记录  删除学生账号
                db.Students.Remove(student);
                db.Users.Remove(user);
                db.SaveChanges();
            }
            catch (Exception ex) 
            {
                return Json(ResultMap.errorMsg("数据库异常，请稍后再试"), JsonRequestBehavior.AllowGet);
            }
            return Json(ResultMap.OK(), JsonRequestBehavior.AllowGet);
        }
    }
}