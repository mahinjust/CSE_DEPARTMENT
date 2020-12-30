using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSE_DEPARTMENT.Models;
using CSE_DEPARTMENT.ViewModel;


namespace CSE_DEPARTMENT.Controllers
{
    public class ShowDataController : Controller
    {
        CSE_DEPARTMENT_DBEntities obj = new CSE_DEPARTMENT_DBEntities();
        // GET: ShowData
        public ActionResult Multidata()
        {

            var mymodel = new Multipledata();

            mymodel.AspNetRole = obj.AspNetRoles.ToList();
            return View(mymodel);
        }

        public ActionResult Multidata2()
        {
            CSE_DEPARTMENT_DBEntities obj = new CSE_DEPARTMENT_DBEntities();
            var mymodel = new Multipledata();
            mymodel.AspNetUser = obj.AspNetUsers.ToList();

            return View(mymodel);
        }
    }
}