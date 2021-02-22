using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSE_DEPARTMENT.Models
{
    public partial class teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public teacher()
        {
            this.routines = new HashSet<routine>();
            this.teacher_career = new HashSet<teacher_career>();
        }

        [Key]
        public int teacher_id { get; set; }
        public string teacher_name { get; set; }
        public string designation { get; set; }

        public string Photo { get; set; }

        [NotMapped]
        public HttpPostedFileBase PhotoFile { get; set; }

        public string work_area { get; set; }
        public string achievement { get; set; }
        public string publication { get; set; }
        public string publication_links { get; set; }
        public string website { get; set; }
        [Display(Name = "UserId")]
        public virtual string Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<routine> routines { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<teacher_career> teacher_career { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}