﻿using System;
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
    public class SalaryInvoicesController : Controller
    {
        private moto_dbEntities db = new moto_dbEntities();

        // GET: SalaryInvoices
        public ActionResult Index()
        {
            var salaryInvoices = db.SalaryInvoices.Include(s => s.User);
            return View(salaryInvoices.ToList());
        }

        // GET: SalaryInvoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryInvoice salaryInvoice = db.SalaryInvoices.Find(id);
            if (salaryInvoice == null)
            {
                return HttpNotFound();
            }
            return View(salaryInvoice);
        }

        // GET: SalaryInvoices/Create
        public ActionResult Create()
        {
            var clients = db.Users.Where(r => r.u_roles == "Ustaz" || r.u_roles == "Ustazah")
               .Select(s => new
               {
                   Text = s.u_id + " - " + s.u_fname,
                   Value = s.u_id
               })
               .ToList();

            ViewBag.u_id = new SelectList(clients, "Value", "Text");
            //ViewBag.u_id = new SelectList(db.Users, "u_id", "u_password");
            return View();
        }

        // POST: SalaryInvoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "i_id,i_amount,i_status,u_id,i_month")] SalaryInvoice salaryInvoice)
        {
            if (ModelState.IsValid)
            {
                db.SalaryInvoices.Add(salaryInvoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.u_id = new SelectList(db.Users, "u_id", "u_password", salaryInvoice.u_id);
            return View(salaryInvoice);
        }

        // GET: SalaryInvoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryInvoice salaryInvoice = db.SalaryInvoices.Find(id);
            if (salaryInvoice == null)
            {
                return HttpNotFound();
            }
            var clients = db.Users.Where(r => r.u_roles == "Ustaz" || r.u_roles == "Ustazah")
               .Select(s => new
               {
                   Text = s.u_id + " - " + s.u_fname,
                   Value = s.u_id
               })
               .ToList();

            ViewBag.u_id = new SelectList(clients, "Value", "Text");
            return View(salaryInvoice);
        }

        // POST: SalaryInvoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "i_id,i_amount,i_status,u_id,i_month")] SalaryInvoice salaryInvoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salaryInvoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.u_id = new SelectList(db.Users, "u_id", "u_password", salaryInvoice.u_id);
            return View(salaryInvoice);
        }

        // GET: SalaryInvoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryInvoice salaryInvoice = db.SalaryInvoices.Find(id);
            if (salaryInvoice == null)
            {
                return HttpNotFound();
            }
            return View(salaryInvoice);
        }

        // POST: SalaryInvoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalaryInvoice salaryInvoice = db.SalaryInvoices.Find(id);
            db.SalaryInvoices.Remove(salaryInvoice);
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
