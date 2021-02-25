using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSE_DEPARTMENT.Models
{
    public partial class staff_career
    {
        [Key]
        public int staffcareer_id { get; set; }
        public int? staff_id { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        [DataType(DataType.Date)]
        public System.DateTime joining_date { get; set; }
      
        public double diploma_result { get; set; }
       
        public string diploma_institute { get; set; }
      
        public double hsc_result { get; set; }
      
        public string hsc_institute { get; set; }
        
        public double ssc_result { get; set; }
      
        public string ssc_institute { get; set; }
        [ForeignKey("staff_id")]
        public virtual Staff Staff { get; set; }
    }
}