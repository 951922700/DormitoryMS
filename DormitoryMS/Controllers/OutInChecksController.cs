using DormitoryMS.Models;
using DormitoryMS.Models.result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DormitoryMS.Controllers
{
    public class OutInChecksController : Controller
    {
        public MyContext db = new MyContext();
        // GET: OutInChecks
        public ActionResult Index()
        {
            return View();
        }

        /*
         * 查询所有携带贵重物品出入学生信息   
         * https://localhost:44376/OutInChecks/getall
         */
        [HttpGet]
        public JsonResult getAll()
        {
            var ds = from item in db.OutInChecks
                     where true //此处可以写条件表达式  
                     select item;
            return Json(ResultMap.OK(ds.ToList()), JsonRequestBehavior.AllowGet);
        }

        /**
         * 携带贵重物品出入登记
         * https://localhost:44376/OutInChecks/add?studentNum=2018017027&itemName=雨伞&date=2020-12-14 21:58:19&remark=
         */
        [HttpPost]
        public JsonResult add(OutInCheck oc)
        {
            db.OutInChecks.Add(oc);
            db.SaveChanges();
            return Json(ResultMap.OK(), JsonRequestBehavior.AllowGet);
        }
    }
}