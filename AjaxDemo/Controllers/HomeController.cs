using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        //Loader Ajax Action Method

        public JsonResult CallingAjaxFunction()
        {
            System.Threading.Thread.Sleep(7000);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}