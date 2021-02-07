using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSE_DEPARTMENT.Models;
using CSE_DEPARTMENT.ViewModel;
using System.Linq.Dynamic;
using PagedList;

namespace CSE_DEPARTMENT.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class ShowDataController : Controller
    {
        CSE_DEPARTMENT_DBEntities obj = new CSE_DEPARTMENT_DBEntities();
        // GET: ShowData
        public ActionResult Multidata(int page = 0)
        {

            return View(obj.AspNetRoles.ToList());
        }

        public ActionResult Multidata2()
        {

            return View(obj.AspNetUsers.ToList());
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







    }
}