using DormitoryMS.Models;
using DormitoryMS.Models.result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DormitoryMS.Controllers
{
    public class StudentsController : Controller
    {
        public MyContext db = new MyContext();
        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

        /**
         * 获取所有学生信息 根据宿舍排
         * https://localhost:44376/students/getAll
         */
        [HttpGet]
        public JsonResult getAll() 
        {
            var ds = from item in db.Students
                     where true //此处可以写条件表达式  降序
                     orderby item.buildingNum descending
                     select item;
            return Json(ResultMap.OK(ds.ToList()), JsonRequestBehavior.AllowGet);
        }

        /**
         * 根据学号查询学生信息   这个没有截图，data内容是查询所有的一个
         * https://localhost:44376/students/getOne?studentNum=2018071027
         */
        [HttpGet]
        public JsonResult getOne(String studentNum) 
        {
            Student student = db.Students.Find(studentNum);
            if (student == null)
                return Json(ResultMap.errorMsg("查无此人，请确认学号是否正确"), JsonRequestBehavior.AllowGet);
            return Json(ResultMap.OK(student), JsonRequestBehavior.AllowGet);
        }

        /**
         * 更新学生信息  不允许在这里修改宿舍号和楼号
         * https://localhost:44376/students/update?studentNum=2018071027&name=蓝永龙&buildingNum=K&dormitoryNum=521&sex=男&major=软件工程&contractInfo=13642425312
         */
        [HttpPost]
        public JsonResult update(Student student) 
        {
            //try懒得写了
            Student s = db.Students.Find(student.studentNum);
            if (s == null)
                return Json(ResultMap.errorMsg("查无此人，请确认学号是否正确"), JsonRequestBehavior.AllowGet);
            //s = student;   不能直接赋值会修改s的引用，导致save操作没办法更新
            s.major = student.major;
            s.name = student.name;
            s.sex = student.sex;
            s.contractInfo = student.contractInfo;
            db.SaveChanges();
            return Json(ResultMap.OK(s), JsonRequestBehavior.AllowGet);
        }


        /**
         * 获取某个学生的宿舍水电费信息
         * https://localhost:44376/students/getwe?studentNum=2016071027
         */
        [HttpGet]
        public JsonResult getWE(String studentNum) 
        {
            //查找学生宿舍信息
            Student student = db.Students.Find(studentNum);
            if (student == null)
                return Json(ResultMap.errorMsg("查无此人，请确认学号是否正确"), JsonRequestBehavior.AllowGet);
            //根据楼号宿舍号查找该宿舍所有
            var ds = from item in db.WaterElectricityCosts
                     where item.buildingNum==student.buildingNum&&item.dormitoryNum==student.dormitoryNum //此处可以写条件表达式  升序
                     orderby item.month ascending
                     select item;
            return Json(ResultMap.OK(ds.ToList()), JsonRequestBehavior.AllowGet);
        }

        /**
         * 填写报修信息
         * https://localhost:44376/students/addRepair/?buildingNum=K&dormitoryNum=520&itemName=灯泡&reason=灯泡坏了&submissionDate=2020-12-15 20:56:15
         */
        [HttpPost]
        public JsonResult addRepair(Repair repair) 
        {
            db.Repairs.Add(repair);
            db.SaveChanges();
            return Json(ResultMap.OK(), JsonRequestBehavior.AllowGet);
        }


        /**
         * 意见反馈
         * https://localhost:44376/students/addFeedBack?content=很棒
         */
        [HttpPost]
        public JsonResult addFeedBack(String content) 
        {
            Feedback feedback = new Feedback();
            feedback.content = content;
            feedback.date = DateTime.Now;
            db.Feedbacks.Add(feedback);
            db.SaveChanges();
            return Json(ResultMap.OK(), JsonRequestBehavior.AllowGet);
        }
    }
}