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
    [Authorize]
    public class current_academicController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: current_academic
        public ActionResult Index()
        {
            var current_academic = db.current_academic.Include(c => c.result).Include(c => c.Session).Include(c => c.student).Include(c => c.Year);
            return View(current_academic.ToList());
        }

        // GET: current_academic/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            current_academic current_academic = db.current_academic.Find(id);
            if (current_academic == null)
            {
                return HttpNotFound();
            }
            return View(current_academic);
        }

        // GET: current_academic/Create
        public ActionResult Create()
        {
            ViewBag.result_id = new SelectList(db.results, "result_id", "result_id");
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name");
            ViewBag.student_id = new SelectList(db.students, "student_id", "Name");
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name");
            return View();
        }

        // POST: current_academic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "currentacademic_id,student_id,Name,Roll,session_id,admission_date,dept,co_curricular_activities,year_id,result_id")] current_academic current_academic)
        {
            if (ModelState.IsValid)
            {
                db.current_academic.Add(current_academic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.result_id = new SelectList(db.results, "result_id", "result_id", current_academic.result_id);
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", current_academic.session_id);
            ViewBag.student_id = new SelectList(db.students, "student_id", "Name", current_academic.student_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", current_academic.year_id);
            return View(current_academic);
        }

        // GET: current_academic/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            current_academic current_academic = db.current_academic.Find(id);
            if (current_academic == null)
            {
                return HttpNotFound();
            }
            ViewBag.result_id = new SelectList(db.results, "result_id", "result_id", current_academic.result_id);
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", current_academic.session_id);
            ViewBag.student_id = new SelectList(db.students, "student_id", "Name", current_academic.student_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", current_academic.year_id);
            return View(current_academic);
        }

        // POST: current_academic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "currentacademic_id,student_id,Name,Roll,session_id,admission_date,dept,co_curricular_activities,year_id,result_id")] current_academic current_academic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(current_academic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.result_id = new SelectList(db.results, "result_id", "result_id", current_academic.result_id);
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", current_academic.session_id);
            ViewBag.student_id = new SelectList(db.students, "student_id", "Name", current_academic.student_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", current_academic.year_id);
            return View(current_academic);
        }

        // GET: current_academic/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            current_academic current_academic = db.current_academic.Find(id);
            if (current_academic == null)
            {
                return HttpNotFound();
            }
            return View(current_academic);
        }

        // POST: current_academic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            current_academic current_academic = db.current_academic.Find(id);
            db.current_academic.Remove(current_academic);
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
