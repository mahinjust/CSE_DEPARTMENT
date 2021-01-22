using CSE_DEPARTMENT.Models;
using CSE_DEPARTMENT.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSE_DEPARTMENT.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class AdminController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Admin

        public ActionResult Index()
        {
            return View();
        }


     

        public ActionResult AssignRole()
        {



            ViewBag.Roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            ViewBag.Users = context.Users.Select(r => new SelectListItem { Value = r.Email, Text = r.Email }).ToList();



            return View();
        }

        [HttpPost]
        public ActionResult AssignRole(FormCollection form)
        {
            string usrname = form["dropUserName"];
            string rolname = form["RoleName"];
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(usrname, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            userManager.AddToRole(user.Id, rolname);
            return RedirectToAction("UsersWithRoles", "ManageUsers");
        }

        public ActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewRole(FormCollection form)
        {
            string rolename = form["RoleName"];
            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());

            if (!rolemanager.RoleExists(rolename))
            {
                //Create Default Role
                var role = new IdentityRole(rolename);
                rolemanager.Create(role);
            }
            return RedirectToAction("Multidata", "ShowData");
        }



    }
}