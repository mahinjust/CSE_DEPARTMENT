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
    public class studentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: students
        public ActionResult Index()
        {
            var students = db.students.Include(s => s.Session).Include(s => s.Year);
            return View(students.ToList());
        }

        // GET: students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: students/Create
        public ActionResult Create()
        {
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name");
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name");
            return View();
        }

        // POST: students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(student student)
        {
            student.Photo = "/Content/StudentPhoto";

            if (ModelState.IsValid)
            {
                db.students.Add(student);
                db.SaveChanges();

                if (student.PhotoFile != null)
                {
                    var folder = "/Content/StudentPhoto";
                    var file = string.Format("{0}.png", student.student_id);
                    var response = FileHelper.UploadFile.UploadPhoto(student.PhotoFile, folder, file);
                    if (response)
                    {
                        var pic = string.Format("{0}/{1}", folder, file);
                        student.Photo = pic;
                        db.Entry(student).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }



                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", student.session_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", student.year_id);
            return View(student);
        }

        // POST: students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "student_id,session_id,year_id,Roll_No,quota,quata_description,skills,hobby,fathers_name,fathers_occupation,fathers_contact_no,mothers_name,mothers_occupation,mothers_contact_no,guardians_name,guardians_occupation,guardians_contact_no")] student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", student.session_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", student.year_id);
            return View(student);
        }

        // GET: students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student student = db.students.Find(id);
            db.students.Remove(student);
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
