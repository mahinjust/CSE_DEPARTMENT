using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSE_DEPARTMENT.Models
{
    public partial class Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Staff()
        {
            this.staff_career = new HashSet<staff_career>();
        }

        [Key]
        public int staff_id { get; set; }
        public string staff_name { get; set; }
        public string Photo { get; set; }
        public string designation { get; set; }
        [Display(Name = "UserId")]
        public virtual string Id { get; set; }

        [NotMapped]
        public HttpPostedFileBase PhotoFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<staff_career> staff_career { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}