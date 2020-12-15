using DormitoryMS.Models;
using DormitoryMS.Models.result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DormitoryMS.Controllers
{
   
    public class RepairsController : Controller
    {
        public MyContext db = new MyContext();
        // GET: Repairs
        public ActionResult Index()
        {
            return View();
        }

        /**
         * 返回所有维修记录
         * https://localhost:44376/repairs/getall
         */
        [HttpGet]
        public JsonResult getAll() 
        {
            var ds = from item in db.Repairs
                     where true //此处可以写条件表达式  升序
                     orderby item.submissionDate ascending
                     select item;
            return Json(ResultMap.OK(ds.ToList()), JsonRequestBehavior.AllowGet);
        }

        /**
         * 传id和解决时间即可
         * 填写解决日期
         * https://localhost:44376/repairs/edit?id=1&resolutionDate=2020-12-15 20:56:15
         */
        [HttpPost]
        public JsonResult edit(Repair repair) 
        {
            Repair r = db.Repairs.Find(repair.id);
            r.resolutionDate = repair.resolutionDate;
            db.SaveChanges();
            return Json(ResultMap.OK(), JsonRequestBehavior.AllowGet);
        }
    }

}