using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using MOTOSystem.Models;

namespace MOTOSystem.Controllers
{
    public class UsersController : Controller
    {
        private moto_dbEntities db = new moto_dbEntities();


        // GET: Users
        public ActionResult Index()
        {

            return View(db.Users.ToList());
        }

        //public ActionResult IndexStudent()
        //{
        //    string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        //    SqlConnection conn = new SqlConnection(connStr);
        //    string sql = "SELECT * from User WHERE u_roles = 'Pelajar'";
        //    SqlCommand cmd = new SqlCommand(sql, conn);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    return View(sql);
        //}

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "u_id,u_password,u_email,u_fname,u_lname,u_roles,u_contact,u_passcode")] User user)
        {
            if (ModelState.IsValid)
            {
                var unhashedPass = user.u_password;
                user.u_password = HashPassword(unhashedPass);
                db.Users.Add(user);
                TempData["AlertMessage"] = "Maklumat pengguna baharu telah berjaya direkodkan.";
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "u_id,u_password,u_email,u_fname,u_lname,u_roles,u_contact,u_passcode")] User user)
        {
            if (ModelState.IsValid)
            {
                var unhashedPass = user.u_password;
                user.u_password = HashPassword(unhashedPass);
                db.Entry(user).State = EntityState.Modified;
                TempData["AlertMessage"] = "Maklumat pengguna telah berjaya dikemaskini.";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult EditProfile(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/EditProfile/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile([Bind(Include = "u_id,u_password,u_email,u_fname,u_lname,u_roles,u_contact,u_passcode")] User user)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(user).State = EntityState.Modified;
                TempData["AlertMessage"] = "Maklumat anda telah berjaya dikemaskini. Sila log masuk semula.";
                db.SaveChanges();
                return RedirectToAction("EditProfile");
            }
            return View(user);
        }

        // GET: Users/ChangePassword/5
        public ActionResult ChangePassword(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/ChangePassword/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword([Bind(Include = "u_id,u_password,u_email,u_fname,u_lname,u_roles,u_contact,u_passcode")] User user)
        {
            if (ModelState.IsValid)
            {
                var unhashedPass = user.u_password;
                user.u_password = HashPassword(unhashedPass);
                db.Entry(user).State = EntityState.Modified;
                TempData["AlertMessage"] = "Kata laluan anda telah berjaya dikemaskini. Sila log masuk semula.";
                db.SaveChanges();
                return RedirectToAction("ChangePassword");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            TempData["AlertMessage"] = "Maklumat pengguna telah berjaya dihapuskan.";
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }
    }
}
