using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CSE_DEPARTMENT.Models
{
    public partial class Subject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subject()
        {
            this.books = new HashSet<book>();
            this.materials = new HashSet<materials>();
            this.routines = new HashSet<routine>();
        }

        [Key]
        public int subject_id { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public double Credit { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string Subject_Name { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string subject_code { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<book> books { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<materials> materials { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<routine> routines { get; set; }
    }
}