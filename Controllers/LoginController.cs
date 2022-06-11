using MOTOSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                var userDetails = db.Users.Where(x => x.u_email == uModel.u_email).FirstOrDefault();
                var PasswordCorrect = VerifyHashedPassword(userDetails.u_password, uModel.u_password);

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
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }

        public static bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            if (b1 == b2) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
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