using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSE_DEPARTMENT.Models
{
    public partial class previous_academic
    {
        [Key]
        public int previousacademic_id { get; set; }
        public int? student_id { get; set; }
      
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public int hsc_roll { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public Int64 hsc_reg { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public double hsc_result { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string hsc_board { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string hsc_college { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string hsc_section { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public int ssc_roll { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public Int64 ssc_reg { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public double ssc_result { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string ssc_board { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string ssc_school { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string ssc_section { get; set; }

        public string co_curricular_activities { get; set; }

        [ForeignKey("student_id")]
        public virtual student student { get; set; }
    }
}