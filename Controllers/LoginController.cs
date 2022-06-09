using MOTOSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MOTOSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(MOTOSystem.Models.User uModel)
        {
            using (moto_dbEntities db = new moto_dbEntities())
            {
                var userDetails = db.Users.Where(x => x.u_email == uModel.u_email && x.u_password == uModel.u_password).FirstOrDefault();
                
                if (userDetails == null)
                {
                    uModel.LoginErrorMessage = " ID Pengguna atau Kata Laluan Tidak Sah";
                    return View("Login", uModel);
                }
                else
                {
                    if (userDetails.u_roles == "Admin")
                    {
                        Session["userID"] = userDetails.u_id;
                        Session["userRole"] = userDetails.u_roles;
                        Session["userName"] = userDetails.u_fname;
                        Session["userLname"] = userDetails.u_lname;
                        return RedirectToAction("ADashboard", "Home");
                    }
                    else if (userDetails.u_roles == "Ustaz" || userDetails.u_roles == "Ustazah")
                    {
                        Session["userID"] = userDetails.u_id;
                        Session["userRole"] = userDetails.u_roles;
                        Session["userName"] = userDetails.u_fname;
                        Session["userLname"] = userDetails.u_lname;
                        return RedirectToAction("TDashboard", "Home");
                    }
                    else
                    {
                        Session["userID"] = userDetails.u_id;
                        Session["userRole"] = userDetails.u_roles;
                        Session["userName"] = userDetails.u_fname;
                        Session["userLname"] = userDetails.u_lname;
                        return RedirectToAction("SDashboard", "Home");
                    }
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove("userID");
            Session.Remove("userName");
            return RedirectToAction("Index", "Home");
        }
    }
}