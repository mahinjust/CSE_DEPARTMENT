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
    public class teacher_careerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: teacher_career
        public ActionResult Index()
        {
            var teacher_career = db.teacher_career.Include(t => t.teacher);
            return View(teacher_career.ToList());
        }

        // GET: teacher_career/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher_career teacher_career = db.teacher_career.Find(id);
            if (teacher_career == null)
            {
                return HttpNotFound();
            }
            return View(teacher_career);
        }

        // GET: teacher_career/Create
        public ActionResult Create()
        {
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name");
            return View();
        }

        // POST: teacher_career/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "teachercareer_id,teacher_id,joining_date,phd_status,phd_institute,msc_status,msc_institute,msc_session,msc_result,bsc_status,bsc_institute,bsc_session,bsc_result,ex_workplaces")] teacher_career teacher_career)
        {
            if (ModelState.IsValid)
            {
                db.teacher_career.Add(teacher_career);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name", teacher_career.teacher_id);
            return View(teacher_career);
        }

        // GET: teacher_career/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher_career teacher_career = db.teacher_career.Find(id);
            if (teacher_career == null)
            {
                return HttpNotFound();
            }
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name", teacher_career.teacher_id);
            return View(teacher_career);
        }

        // POST: teacher_career/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "teachercareer_id,teacher_id,joining_date,phd_status,phd_institute,msc_status,msc_institute,msc_session,msc_result,bsc_status,bsc_institute,bsc_session,bsc_result,ex_workplaces")] teacher_career teacher_career)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher_career).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name", teacher_career.teacher_id);
            return View(teacher_career);
        }

        // GET: teacher_career/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher_career teacher_career = db.teacher_career.Find(id);
            if (teacher_career == null)
            {
                return HttpNotFound();
            }
            return View(teacher_career);
        }

        // POST: teacher_career/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            teacher_career teacher_career = db.teacher_career.Find(id);
            db.teacher_career.Remove(teacher_career);
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
