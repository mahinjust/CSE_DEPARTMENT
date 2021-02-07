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
    public class noticesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: notices
        public ActionResult Index()
        {
            return View(db.notices.ToList());
        }

        // GET: notices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice notice = db.notices.Find(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }

        // GET: notices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: notices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "notice_id,notice_upload,notice_topic,published_by,publish_date,created_by,created_date,updated_by,updated_date,deadline,priority,specification")] notice notice)
        {
            if (ModelState.IsValid)
            {
                db.notices.Add(notice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notice);
        }

        // GET: notices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice notice = db.notices.Find(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }

        // POST: notices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "notice_id,notice_upload,notice_topic,published_by,publish_date,created_by,created_date,updated_by,updated_date,deadline,priority,specification")] notice notice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notice);
        }

        // GET: notices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice notice = db.notices.Find(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }

        // POST: notices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            notice notice = db.notices.Find(id);
            db.notices.Remove(notice);
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
