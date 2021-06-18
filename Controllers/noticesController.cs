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
    public class noticesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: notices
        public ActionResult Index()
        {
            List<notice> ObjFiles = new List<notice>();
            foreach (string strfile in Directory.GetFiles(Server.MapPath("~/Files")))
            {
                FileInfo fi = new FileInfo(strfile);
                notice obj = new notice();
                obj.File = fi.Name;
                obj.Size = fi.Length;
                obj.Type = GetFileTypeByExtension(fi.Extension);
                ObjFiles.Add(obj);
            }

            return View(ObjFiles);
        }

        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Files"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);



            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public ActionResult Delete(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Files"), fileName);
            FileInfo file = new FileInfo(fullPath);
            if (file.Exists)//check file exsit or not  
            {
                file.Delete();

            }

            return RedirectToAction("Index");
        }

        private string GetFileTypeByExtension(string fileExtension)
        {
            switch (fileExtension.ToLower())
            {
                case ".docx":
                case ".doc":
                    return "Microsoft Word Document";
                case ".pdf":
                    return "Portable Document Format";
                case ".xlsx":
                case ".xls":
                    return "Microsoft Excel Document";
                case ".pptx":
                    return "Microsoft PowerPoint Document";
                case ".txt":
                    return "Text Document";
                case ".jpg":
                case ".png":
                case ".jpeg":
                    return "Image";
                case ".gif":
                    return "Graphics Interchange Format file";
                case ".c":
                    return "C language file";
                case ".CPP":
                    return "C++ language file";
                case ".php":
                    return "PHP language file";
                case ".py":
                    return "Python language file";
                case ".zip":
                    return "Zip file";
                default:
                    return "Unknown";
            }
        }


        [HttpPost]
        public ActionResult Index(notice doc)
        {
            foreach (var file in doc.files)
            {

                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Server.MapPath("~/Files"), fileName);
                    file.SaveAs(filePath);
                }
            }


            TempData["Message"] = "Files Uploaded Successfully!";
            return RedirectToAction("Index");
        }





    }



    //// GET: notices/Details/5
    //public ActionResult Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        notice notice = db.notices.Find(id);
    //        if (notice == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(notice);
    //    }

    //    // GET: notices/Create
    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: notices/Create
    //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create([Bind(Include = "notice_id,notice_upload,notice_topic,published_by,publish_date,created_by,created_date,updated_by,updated_date,deadline,priority,specification")] notice notice)
    //    {
    //        if (ModelState.IsValid)
    //        {

    //            db.notices.Add(notice);
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }

    //        return View(notice);
    //    }

    //    // GET: notices/Edit/5
    //    public ActionResult Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        notice notice = db.notices.Find(id);
    //        if (notice == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(notice);
    //    }

    //    // POST: notices/Edit/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit([Bind(Include = "notice_id,notice_upload,notice_topic,published_by,publish_date,created_by,created_date,updated_by,updated_date,deadline,priority,specification")] notice notice)
    //    {
    //        if (ModelState.IsValid)
    //        {


    //            db.Entry(notice).State = EntityState.Modified;
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }
    //        return View(notice);
    //    }

    //    // GET: notices/Delete/5
    //    public ActionResult Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        notice notice = db.notices.Find(id);
    //        if (notice == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(notice);
    //    }

    // POST: notices/Delete/5
    //[HttpPost, ActionName("Delete")]
    //        [ValidateAntiForgeryToken]
    //        public ActionResult DeleteConfirmed(int id)
    //        {
    //            notice notice = db.notices.Find(id);
    //            db.notices.Remove(notice);
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }

    //        protected override void Dispose(bool disposing)
    //        {
    //            if (disposing)
    //            {
    //                db.Dispose();
    //            }
    //            base.Dispose(disposing);
    //        }
    //    }
}

//public class ObjFile
//{
//    public IEnumerable<HttpPostedFileBase> files { get; set; }
//    public string File { get; set; }
//    public long Size { get; set; }
//    public string Type { get; set; }
//}