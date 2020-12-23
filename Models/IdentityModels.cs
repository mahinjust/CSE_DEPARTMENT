using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CSE_DEPARTMENT.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }

       

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.activities> activities { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.student> students { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.book> books { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.Subject> Subjects { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.Year> Years { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.current_academic> current_academic { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.result> results { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.Session> Sessions { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.materials> materials { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.notice> notices { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.previous_academic> previous_academic { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.routine> routines { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.teacher> teachers { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.Staff> Staffs { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.staff_career> staff_career { get; set; }

        public System.Data.Entity.DbSet<CSE_DEPARTMENT.Models.teacher_career> teacher_career { get; set; }
    }
}