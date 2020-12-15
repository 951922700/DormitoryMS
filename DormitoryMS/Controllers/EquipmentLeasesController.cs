using DormitoryMS.Models;
using DormitoryMS.Models.result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DormitoryMS.Controllers
{
    public class EquipmentLeasesController : Controller
    {

        public MyContext db = new MyContext();
        // GET: EquipmentLeases
        public ActionResult Index()
        {
            return View();
        }

        /**
         * 获取所有租赁信息
         * https://localhost:44376/EquipmentLeases/getall
         */
        [HttpGet]
        public JsonResult getAll()
        {
            var ds = from item in db.EquipmentLeases
                     where true //此处可以写条件表达式  升序
                     orderby item.leaseDate ascending
                     select item;
            return Json(ResultMap.OK(ds.ToList()), JsonRequestBehavior.AllowGet);
        }

        /**
         * 获取未归还租赁信息
         * https://localhost:44376/EquipmentLeases/getnoreturn
         */
        [HttpGet]
        public JsonResult getNoReturn()
        {
            var ds = from item in db.EquipmentLeases
                     where item.returnDate==null //此处可以写条件表达式  升序
                     orderby item.leaseDate ascending
                     select item;
            return Json(ResultMap.OK(ds.ToList()), JsonRequestBehavior.AllowGet);
        }

        /**
         * 租赁信息登记   传学号 器材名 器材数量
         * https://localhost:44376/EquipmentLeases/regist?studentNum=2018071027&equNum=32&equName=乒乓球
         */
        [HttpPost]
        public JsonResult regist(EquipmentLease el) 
        {
            el.leaseDate = DateTime.Now;//传时间
            db.EquipmentLeases.Add(el);
            db.SaveChanges();
            return Json(ResultMap.OK(), JsonRequestBehavior.AllowGet);
        }

        /**
         * 填写归还日期  根据id查询对应记录
         * https://localhost:44376/EquipmentLeases/edit?id=2&returnDate=2020-12-11 20:39:06
         */
        [HttpPost]
        public JsonResult edit(EquipmentLease el) 
        {
            EquipmentLease e= db.EquipmentLeases.Find(el.id);
            e.returnDate = el.returnDate;
            db.SaveChanges();
            return Json(ResultMap.OK(), JsonRequestBehavior.AllowGet);
        }
    }
}