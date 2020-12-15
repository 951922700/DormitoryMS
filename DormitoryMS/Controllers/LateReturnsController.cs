using DormitoryMS.Models;
using DormitoryMS.Models.result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DormitoryMS.Controllers
{
    public class LateReturnsController : Controller
    {
        public MyContext db = new MyContext();
        // GET: LateReturns
        public ActionResult Index()
        {
            return View();
        }

        /*
         * 查询所有晚归信息   
         * https://localhost:44376/LateReturns/getall
         */
        [HttpGet]
        public JsonResult getAll()
        {
            var ds = from item in db.LateReturns
                     where true //此处可以写条件表达式  
                     select item;
            return Json(ResultMap.OK(ds.ToList()), JsonRequestBehavior.AllowGet);
        }

        /**
         * 晚归登记
         * https://localhost:44376/LateReturns/add?studentNum=2018071027&reason=学习&date=2020-12-15 21:58:19
         */
        [HttpPost]
        public JsonResult add(LateReturn lr)
        {
            db.LateReturns.Add(lr);
            db.SaveChanges();
            return Json(ResultMap.OK(), JsonRequestBehavior.AllowGet);
        }
    }
}