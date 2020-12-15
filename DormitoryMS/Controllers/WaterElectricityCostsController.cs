using DormitoryMS.Models;
using DormitoryMS.Models.result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DormitoryMS.Controllers
{
    public class WaterElectricityCostsController : Controller
    {
        public MyContext db = new MyContext();
        // GET: WaterElectricityCosts
        public ActionResult Index()
        {
            return View();
        }

        /**
         * 获取所有水电费信息
         * https://localhost:44376/WaterElectricityCosts/getall
         */
        [HttpGet]
        public JsonResult getAll() 
        {
            var ds = from item in db.WaterElectricityCosts
                     where true //此处可以写条件表达式  升序
                     orderby item.buildingNum ascending
                     select item;
            return Json(ResultMap.OK(ds.ToList()), JsonRequestBehavior.AllowGet);
        }
    }
}