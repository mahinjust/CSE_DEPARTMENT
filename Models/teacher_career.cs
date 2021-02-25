using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSE_DEPARTMENT.Models
{
    public partial class teacher_career
    {
        [Key]
        public int teachercareer_id { get; set; }
        public int? teacher_id { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        [DataType(DataType.Date)]
        public System.DateTime joining_date { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string phd_status { get; set; }
        public string phd_institute { get; set; }
        
        public string msc_status { get; set; }
        
        public string msc_institute { get; set; }
       
        public string msc_session { get; set; }
      
        public double msc_result { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string bsc_status { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string bsc_institute { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string bsc_session { get; set; }
        public double bsc_result { get; set; }
        public string ex_workplaces { get; set; }
        [ForeignKey("teacher_id")]
        public virtual teacher teacher { get; set; }
    }
}