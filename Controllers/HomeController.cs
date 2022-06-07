using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOTOSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult ADashboard()
        {
            return View();
        }

        public ActionResult TDashboard()
        {
            return View();
        }

        public ActionResult SDashboard()
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
    }
}