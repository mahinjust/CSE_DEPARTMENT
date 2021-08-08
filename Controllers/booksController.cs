using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSE_DEPARTMENT.Models;

namespace CSE_DEPARTMENT.Controllers
{
    [Authorize]
    public class booksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: books
        public ActionResult Index()
        {

            var books = db.books.Include(b => b.Subject).Include(b => b.Year);
            return View(books.ToList());
        }

        // GET: books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: books/Create
        public ActionResult Create()
        {
        
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name");
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name");
            return View();
        }

        // POST: books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(book book)
        {
            //if (ModelState.IsValid)
            //{
            //    db.books.Add(book);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //book.Pdf = "/Content/Books";

            //if (ModelState.IsValid)
            //{
            //    db.books.Add(book);
            //    db.SaveChanges();

            //    if (book.PdfFile != null && book.PdfFile.ContentLength < 5000000)
            //    {
            //        var folder = "/Content/Books";
            //        var file = string.Format("{0}.pdf",book.book_name);
            //        var response = FileHelper.UploadFile.UploadPhoto(book.PdfFile, folder, file);
            //        if (response)
            //        {
            //            var pic = string.Format("{0}/{1}",folder, file);
            //            book.Pdf = pic;
            //            db.Entry(book).State = EntityState.Modified;
            //            db.SaveChanges();
            //        }
            //    }

            //   return RedirectToAction("Index");
            //}

            if (ModelState.IsValid)
            {
                foreach (var file in book.files)
                {

                    if (file.ContentLength < 5000000)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Books"), fileName);
                        file.SaveAs(filePath);
                    }

                    db.books.Add(book);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }

            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", book.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", book.year_id);
            return View(book);
        }



        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Books"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }


        //private string GetFileTypeByExtension(string fileExtension)
        //{
        //    switch (fileExtension.ToLower())
        //    {
        //        case ".docx":
        //        case ".doc":
        //            return "Microsoft Word Document";
        //        case ".pdf":
        //            return "Portable Document Format";
        //        case ".xlsx":
        //        case ".xls":
        //            return "Microsoft Excel Document";
        //        case ".pptx":
        //            return "Microsoft PowerPoint Document";
        //        case ".txt":
        //            return "Text Document";
        //        case ".jpg":
        //        case ".png":
        //        case ".jpeg":
        //            return "Image";
        //        case ".gif":
        //            return "Graphics Interchange Format file";
        //        case ".c":
        //            return "C language file";
        //        case ".CPP":
        //            return "C++ language file";
        //        case ".php":
        //            return "PHP language file";
        //        case ".py":
        //            return "Python language file";
        //        case ".zip":
        //            return "Zip file";
        //        default:
        //            return "Unknown";
        //    }
        //}






        // GET: books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", book.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", book.year_id);
            return View(book);
        }

        // POST: books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "book_id,year_id,book_name,book_author,specification,edition,subject_id")] book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", book.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", book.year_id);
            return View(book);
        }

        // GET: books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            book book = db.books.Find(id);
            db.books.Remove(book);
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
