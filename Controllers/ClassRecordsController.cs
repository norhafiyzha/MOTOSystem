using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MOTOSystem.Models;

namespace MOTOSystem.Controllers
{
    public class ClassRecordsController : Controller
    {
        private moto_dbEntities db = new moto_dbEntities();

        // GET: ClassRecords
        public ActionResult Index()
        {
            var classRecords = db.ClassRecords.Include(c => c.Class_Package1).Include(c => c.User);
            return View(classRecords.ToList());
        }

        // GET: ClassRecords/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassRecord classRecord = db.ClassRecords.Find(id);
            if (classRecord == null)
            {
                return HttpNotFound();
            }
            return View(classRecord);
        }

        // GET: ClassRecords/Create
        public ActionResult Create()
        {
            var clients = db.Users
                .Select(s => new
                {
                    Text = s.u_id+ " - " + s.u_fname,
                    Value = s.u_id
                })
                .ToList();

            ViewBag.u_id = new SelectList(clients, "Value", "Text");
            ViewBag.class_package = new SelectList(db.Class_Packages, "cp_id", "cp_name");
           // ViewBag.u_id = new SelectList(db.Users, "u_id", "u_id");
            return View();
        }

        // POST: ClassRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "class_id,u_id,class_time,class_teacher,class_package")] ClassRecord classRecord)
        {
            if (ModelState.IsValid)
            {
                db.ClassRecords.Add(classRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.class_package = new SelectList(db.Class_Packages, "cp_id", "cp_name", classRecord.class_package);
            ViewBag.u_id = new SelectList(db.Users, "u_id", "u_id", classRecord.u_id);
            return View(classRecord);
        }

        // GET: ClassRecords/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassRecord classRecord = db.ClassRecords.Find(id);
            if (classRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.class_package = new SelectList(db.Class_Packages, "cp_id", "cp_name", classRecord.class_package);
            ViewBag.u_id = new SelectList(db.Users, "u_id", "u_password", classRecord.u_id);
            return View(classRecord);
        }

        // POST: ClassRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "class_id,u_id,class_time,class_teacher,class_package")] ClassRecord classRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.class_package = new SelectList(db.Class_Packages, "cp_id", "cp_name", classRecord.class_package);
            ViewBag.u_id = new SelectList(db.Users, "u_id", "u_password", classRecord.u_id);
            return View(classRecord);
        }

        // GET: ClassRecords/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassRecord classRecord = db.ClassRecords.Find(id);
            if (classRecord == null)
            {
                return HttpNotFound();
            }
            return View(classRecord);
        }

        // POST: ClassRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ClassRecord classRecord = db.ClassRecords.Find(id);
            db.ClassRecords.Remove(classRecord);
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
    }
}
