using DormitoryMS.Models;
using DormitoryMS.Models.result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DormitoryMS.Controllers
{
    public class VisitorInfosController : Controller
    {
        public MyContext db = new MyContext();
        // GET: VisitorInfos
        public ActionResult Index()
        {
            return View();
        }

        /*
         * 查询所有来访者记录   
         * https://localhost:44376/VisitorInfos/getall
         */
        [HttpGet]
        public JsonResult getAll()
        {
            var ds = from item in db.VisitorInfos
                     where true //此处可以写条件表达式  升序
                     orderby item.date ascending
                     select item;
            return Json(ResultMap.OK(ds.ToList()), JsonRequestBehavior.AllowGet);
        }

        /**
         * 来访者登记
         * https://localhost:44376/VisitorInfos/add?visitorName=叽叽喳喳&visitedPeopleNum=2018071027&date=2020-12-14 21:39:54&endTime=2020-12-14 23:40:02&remark=无
         */
        [HttpPost]
        public JsonResult add(VisitorInfo vs) 
        {
            db.VisitorInfos.Add(vs);
            db.SaveChanges();
            return Json(ResultMap.OK(), JsonRequestBehavior.AllowGet);
        }
            
        
    }
}