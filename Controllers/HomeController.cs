using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOTOSystem.Models;

namespace MOTOSystem.Controllers
    //shasither
{
    public class HomeController : Controller
    {
       
        public ActionResult ADashboard()
        {
            using (moto_dbEntities db = new moto_dbEntities())
            {
                var user = db.Users.Count();
                var admin = db.Users.Where(x => x.u_roles == "Admin").Count();
                var teacher = db.Users.Where(x => x.u_roles == "Ustaz" || x.u_roles == "Ustazah").Count();
                var student = db.Users.Where(x => x.u_roles == "Pelajar").Count();
                ViewBag.User = user;
                ViewBag.Admin = admin;
                ViewBag.Teacher = teacher;
                ViewBag.Student = student;

            }
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