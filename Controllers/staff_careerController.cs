using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSE_DEPARTMENT.Models;

namespace CSE_DEPARTMENT.Controllers
{
    public class staff_careerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: staff_career
        public ActionResult Index()
        {
            var staff_career = db.staff_career.Include(s => s.Staff);
            return View(staff_career.ToList());
        }

        // GET: staff_career/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff_career staff_career = db.staff_career.Find(id);
            if (staff_career == null)
            {
                return HttpNotFound();
            }
            return View(staff_career);
        }

        // GET: staff_career/Create
        public ActionResult Create()
        {
            ViewBag.staff_id = new SelectList(db.Staffs, "staff_id", "staff_name");
            return View();
        }

        // POST: staff_career/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "staffcareer_id,staff_id,joining_date,diploma_result,diploma_institute,hsc_result,hsc_institute,ssc_result,ssc_institute")] staff_career staff_career)
        {
            if (ModelState.IsValid)
            {
                db.staff_career.Add(staff_career);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.staff_id = new SelectList(db.Staffs, "staff_id", "staff_name", staff_career.staff_id);
            return View(staff_career);
        }

        // GET: staff_career/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff_career staff_career = db.staff_career.Find(id);
            if (staff_career == null)
            {
                return HttpNotFound();
            }
            ViewBag.staff_id = new SelectList(db.Staffs, "staff_id", "staff_name", staff_career.staff_id);
            return View(staff_career);
        }

        // POST: staff_career/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "staffcareer_id,staff_id,joining_date,diploma_result,diploma_institute,hsc_result,hsc_institute,ssc_result,ssc_institute")] staff_career staff_career)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff_career).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.staff_id = new SelectList(db.Staffs, "staff_id", "staff_name", staff_career.staff_id);
            return View(staff_career);
        }

        // GET: staff_career/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff_career staff_career = db.staff_career.Find(id);
            if (staff_career == null)
            {
                return HttpNotFound();
            }
            return View(staff_career);
        }

        // POST: staff_career/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            staff_career staff_career = db.staff_career.Find(id);
            db.staff_career.Remove(staff_career);
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
