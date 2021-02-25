using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSE_DEPARTMENT.Models
{
    public partial class current_academic
    {
        [Key]
        public int currentacademic_id { get; set; }
        
        public int? student_id { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public int Roll { get; set; }

        public int? session_id { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        [DataType(DataType.Date)]
        public System.DateTime admission_date { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string dept { get; set; }

        public string co_curricular_activities { get; set; }
        public int? year_id { get; set; }
        public int? result_id { get; set; }

        [ForeignKey("result_id")]
        public virtual result result { get; set; }
        [ForeignKey("session_id")]
        public virtual Session Session { get; set; }
        [ForeignKey("student_id")]
        public virtual student student { get; set; }
        [ForeignKey("year_id")]
     
        public virtual Year Year { get; set; }
    }
}