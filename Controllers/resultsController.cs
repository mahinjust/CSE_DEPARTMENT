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
    public class resultsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: results
        public ActionResult Index()
        {
            var results = db.results.Include(r => r.Session).Include(r => r.student).Include(r => r.Year);
            return View(results.ToList());
        }

        // GET: results/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            result result = db.results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // GET: results/Create
        public ActionResult Create()
        {
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name");
            ViewBag.student_id = new SelectList(db.students, "student_id", "Name");
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name");
            return View();
        }

        // POST: results/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "result_id,Roll_No,Name,student_id,session_id,year_id,cgpa")] result result)
        {
            if (ModelState.IsValid)
            {
                db.results.Add(result);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", result.session_id);
            ViewBag.student_id = new SelectList(db.students, "student_id", "Name", result.student_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", result.year_id);
            return View(result);
        }

        // GET: results/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            result result = db.results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", result.session_id);
            ViewBag.student_id = new SelectList(db.students, "student_id", "Name", result.student_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", result.year_id);
            return View(result);
        }

        // POST: results/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "result_id,Roll_No,Name,student_id,session_id,year_id,cgpa")] result result)
        {
            if (ModelState.IsValid)
            {
                db.Entry(result).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", result.session_id);
            ViewBag.student_id = new SelectList(db.students, "student_id", "Name", result.student_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", result.year_id);
            return View(result);
        }

        // GET: results/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            result result = db.results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // POST: results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            result result = db.results.Find(id);
            db.results.Remove(result);
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
