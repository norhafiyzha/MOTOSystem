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
                var package = db.Class_Packages.Count();
                ViewBag.User = user;
                ViewBag.Admin = admin;
                ViewBag.Teacher = teacher;
                ViewBag.Student = student;
                ViewBag.Package = package;

            }
            return View();
        }

        public ActionResult TDashboard()
        {
            using (moto_dbEntities db = new moto_dbEntities())
            {
                var teacher = db.Users.Where(x => x.u_roles == "Ustaz" || x.u_roles == "Ustazah").Count();
                var student = db.Users.Where(x => x.u_roles == "Pelajar").Count();
                var package = db.Class_Packages.Count();
                var performance = db.PerformanceReports.Count();
                ViewBag.Teacher = teacher;
                ViewBag.Package = package;
                ViewBag.Student = student;
                ViewBag.Performance = performance;

            }
            return View();
        }

        public ActionResult SDashboard()
        {
            using (moto_dbEntities db = new moto_dbEntities())
            {
                var teacher = db.Users.Where(x => x.u_roles == "Ustaz" || x.u_roles == "Ustazah").Count();
                var package = db.Class_Packages.Count();
                ViewBag.Teacher = teacher;
                ViewBag.Package = package;

            }
            return View();
        }

    }
}