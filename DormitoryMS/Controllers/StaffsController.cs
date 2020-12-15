using DormitoryMS.Models;
using DormitoryMS.Models.result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DormitoryMS.Controllers
{
    public class StaffsController : Controller
    {
        public MyContext db = new MyContext();
        // GET: Staffs
        public ActionResult Index()
        {
            return View();
        }

        /**
         * 获取所有员工信息
         * https://localhost:44376/staffs/getall
         */
        [HttpGet]
        public JsonResult getAll()
        {
            var ds = from item in db.Staffs
                     where true //此处可以写条件表达式  升序
                     orderby item.staffNum ascending
                     select item;
            return Json(ResultMap.OK(ds.ToList()), JsonRequestBehavior.AllowGet);
        }

        /**
         * 根据员工号查询员工信息  无截图
         * https://localhost:44376/staffs/getone?staffNum=1
         */
        [HttpGet]
        public JsonResult getOne(int staffNum)
        {
            Staff staff = db.Staffs.Find(staffNum);
            if (staff == null)
                return Json(ResultMap.errorMsg("查无此人，请确认员工号是否正确"), JsonRequestBehavior.AllowGet);
            return Json(ResultMap.OK(staff), JsonRequestBehavior.AllowGet);
        }

        /**
         * 更新员工信息  
         * https://localhost:44376/staffs/update?staffNum=1&name=何定炜&position=清洁工&sex=男&age=32&contractInfo=13642425678
         */
        [HttpPost]
        public JsonResult update(Staff staff)
        {

            Staff s = db.Staffs.Find(staff.staffNum);
            s.name = staff.name;
            s.position = staff.position;
            s.sex = staff.sex;
            s.age = staff.age;
            s.contractInfo = staff.contractInfo;
            db.SaveChanges();
            return Json(ResultMap.OK(s), JsonRequestBehavior.AllowGet);
        }
    }
}