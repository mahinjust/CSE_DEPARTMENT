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

        public string Name { get; set; }

        public int hsc_roll { get; set; }
        public int hsc_reg { get; set; }
        public double hsc_result { get; set; }
        public string hsc_board { get; set; }
        public string hsc_college { get; set; }
        public string hsc_section { get; set; }
        public int ssc_roll { get; set; }
        public int ssc_reg { get; set; }
        public double ssc_result { get; set; }
        public string ssc_board { get; set; }
        public string ssc_school { get; set; }
        public string ssc_section { get; set; }

        public string co_curricular_activities { get; set; }

        [ForeignKey("student_id")]
        public virtual student student { get; set; }
    }
}