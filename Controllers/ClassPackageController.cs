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
    public class ClassPackageController : Controller
    {
        private moto_dbEntities db = new moto_dbEntities();

        // GET: ClassPackage
        public ActionResult Index()
        {
            return View(db.Class_Packages.ToList());
        }

        // GET: ClassPackage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class_Package class_Package = db.Class_Packages.Find(id);
            if (class_Package == null)
            {
                return HttpNotFound();
            }
            return View(class_Package);
        }

        // GET: ClassPackage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassPackage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cp_id,cp_name,cp_fees")] Class_Package class_Package)
        {
            if (ModelState.IsValid)
            {
                db.Class_Packages.Add(class_Package);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(class_Package);
        }

        // GET: ClassPackage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class_Package class_Package = db.Class_Packages.Find(id);
            if (class_Package == null)
            {
                return HttpNotFound();
            }
            return View(class_Package);
        }

        // POST: ClassPackage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cp_id,cp_name,cp_fees")] Class_Package class_Package)
        {
            if (ModelState.IsValid)
            {
                db.Entry(class_Package).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(class_Package);
        }

        // GET: ClassPackage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class_Package class_Package = db.Class_Packages.Find(id);
            if (class_Package == null)
            {
                return HttpNotFound();
            }
            return View(class_Package);
        }

        // POST: ClassPackage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Class_Package class_Package = db.Class_Packages.Find(id);
            db.Class_Packages.Remove(class_Package);
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
