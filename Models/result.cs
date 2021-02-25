using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSE_DEPARTMENT.Models
{
    public partial class result
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public result()
        {
            this.current_academic = new HashSet<current_academic>();
        }

        [Key]
        public int result_id { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public int Roll_No { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string Name { get; set; }
        public int? student_id { get; set; }
        public int? session_id { get; set; }
        public int? year_id { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public double cgpa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<current_academic> current_academic { get; set; }
        [ForeignKey("session_id")]
        public virtual Session Session { get; set; }
        [ForeignKey("student_id")]
        public virtual student student { get; set; }
        [ForeignKey("year_id")]
        public virtual Year Year { get; set; }
    }
}