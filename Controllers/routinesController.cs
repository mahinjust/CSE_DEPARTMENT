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
    public class routinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: routines
        public ActionResult Index()
        {
            var routines = db.routines.Include(r => r.Session).Include(r => r.Subject).Include(r => r.teacher);
            return View(routines.ToList());
        }

        // GET: routines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine routine = db.routines.Find(id);
            if (routine == null)
            {
                return HttpNotFound();
            }
            return View(routine);
        }

        // GET: routines/Create
        public ActionResult Create()
        {
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name");
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name");
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name");
            return View();
        }

        // POST: routines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "routine_id,routine_upload,class_date,day,teacher_id,subject_id,session_id,start_time,end_time,duration,comment")] routine routine)
        {
            if (ModelState.IsValid)
            {
                db.routines.Add(routine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine.session_id);
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", routine.subject_id);
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name", routine.teacher_id);
            return View(routine);
        }

        // GET: routines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine routine = db.routines.Find(id);
            if (routine == null)
            {
                return HttpNotFound();
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine.session_id);
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", routine.subject_id);
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name", routine.teacher_id);
            return View(routine);
        }

        // POST: routines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "routine_id,routine_upload,class_date,day,teacher_id,subject_id,session_id,start_time,end_time,duration,comment")] routine routine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine.session_id);
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", routine.subject_id);
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name", routine.teacher_id);
            return View(routine);
        }

        // GET: routines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine routine = db.routines.Find(id);
            if (routine == null)
            {
                return HttpNotFound();
            }
            return View(routine);
        }

        // POST: routines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            routine routine = db.routines.Find(id);
            db.routines.Remove(routine);
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