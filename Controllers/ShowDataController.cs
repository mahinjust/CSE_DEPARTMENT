using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSE_DEPARTMENT.Models;
using CSE_DEPARTMENT.ViewModel;
using System.Linq.Dynamic;

namespace CSE_DEPARTMENT.Controllers
{
    public class ShowDataController : Controller
    {
        CSE_DEPARTMENT_DBEntities obj = new CSE_DEPARTMENT_DBEntities();
        // GET: ShowData
        public ActionResult Multidata(int page = 1, string sort = "Name", string sortdir = "asc", string search = "")
        {

            int pageSize = 10;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pageSize) - pageSize;
            var data = GetRoles(search, sort, sortdir, skip, pageSize, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.search = search;
            return View(data);
        }

        public ActionResult Multidata2(int page = 1, string sort = "Email", string sortdir = "asc", string search = "")
        {

            int pageSize = 10;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pageSize) - pageSize;
            var data = GetUsers(search, sort, sortdir, skip, pageSize, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.search = search;
            return View(data);

        }



        public ActionResult Delete(string Id)
        {
            var model = obj.AspNetUsers.Find(Id);
            obj.AspNetUsers.Remove(model);
            obj.SaveChanges();
            return RedirectToAction("Multidata2", "ShowData");
        }

        public ActionResult DeleteRole(string Id)
        {
            var model = obj.AspNetRoles.Find(Id);
            obj.AspNetRoles.Remove(model);
            obj.SaveChanges();
            return RedirectToAction("Multidata", "ShowData");
        }

        public List<AspNetUser> GetUsers(string search, string sort, string sortdir, int skip, int pageSize, out int totalRecord)
        {
            using (CSE_DEPARTMENT_DBEntities obj = new CSE_DEPARTMENT_DBEntities())
            {
                var v = (from a in obj.AspNetUsers
                         where
                                 a.Id.Contains(search) ||
                                 a.Email.Contains(search) ||
                                 a.PhoneNumber.Contains(search)

                         select a
                                );
                totalRecord = v.Count();
                v = v.OrderBy(sort + " " + sortdir);
                if (pageSize > 0)
                {
                    v = v.Skip(skip).Take(pageSize);
                }
                return v.ToList();
            }
        }

        public List<AspNetRole> GetRoles(string search, string sort, string sortdir, int skip, int pageSize, out int totalRecord)
        {
            using (CSE_DEPARTMENT_DBEntities obj = new CSE_DEPARTMENT_DBEntities())
            {
                var v = (from a in obj.AspNetRoles
                         where
                                 a.Id.Contains(search) ||
                                 a.Name.Contains(search)


                         select a
                                );
                totalRecord = v.Count();
                v = v.OrderBy(sort + " " + sortdir);
                if (pageSize > 0)
                {
                    v = v.Skip(skip).Take(pageSize);
                }
                return v.ToList();
            }
        }


    }
}