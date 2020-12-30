using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSE_DEPARTMENT.Models
{
    public partial class student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public student()
        {
            this.results = new HashSet<result>();
            this.activities = new HashSet<activities>();
            this.current_academic = new HashSet<current_academic>();
            this.previous_academic = new HashSet<previous_academic>();
        }

        [Key]
        public int student_id { get; set; }
        public int? session_id { get; set; }
        public int? year_id { get; set; }
        public int Roll_No { get; set; }
        public bool quota { get; set; }
        public string quata_description { get; set; }
        public string skills { get; set; }
        public string hobby { get; set; }
        public string fathers_name { get; set; }
        public string fathers_occupation { get; set; }
        public string fathers_contact_no { get; set; }
        public string mothers_name { get; set; }
        public string mothers_occupation { get; set; }
        public string mothers_contact_no { get; set; }
        public string guardians_name { get; set; }
        public string guardians_occupation { get; set; }
        public string guardians_contact_no { get; set; }
        [Display(Name = "UserId")]
        public virtual string Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<result> results { get; set; }
        [ForeignKey("session_id")]
        public virtual Session Session { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<activities> activities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<current_academic> current_academic { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<previous_academic> previous_academic { get; set; }
        [ForeignKey("year_id")]
        public virtual Year Year { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}