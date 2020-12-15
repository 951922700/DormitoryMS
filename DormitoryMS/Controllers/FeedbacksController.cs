using DormitoryMS.Models;
using DormitoryMS.Models.result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DormitoryMS.Controllers
{
    public class FeedbacksController : Controller
    {

        public MyContext db = new MyContext();
        // GET: Feedbacks
        public ActionResult Index()
        {
            return View();
        }

        /**
         * 返回所有反馈信息
         * https://localhost:44376/Feedbacks/getall
         */
        [HttpGet]
        public JsonResult getAll() 
        {
            var ds = from item in db.Feedbacks
                     where true //此处可以写条件表达式 
                     orderby item.date ascending
                     select item;
            return Json(ResultMap.OK(ds.ToList()), JsonRequestBehavior.AllowGet);
        }
    }
}