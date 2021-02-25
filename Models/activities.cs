using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CSE_DEPARTMENT.Models
{
 
    public partial class activities
    {
        [Key]
        public int activities_id { get; set; }
        [Required(ErrorMessage ="This Is A Required Field!!")]
        public int Roll { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string Name { get; set; }
        public int? student_id { get; set; }
        public bool club_membership { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string club_name { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string designation { get; set; }
        public string achievement { get; set; }
        public bool others_co_curricular_activities { get; set; }
        public string description { get; set; }

        [ForeignKey("student_id")]
        public virtual student student { get; set; }
    }
}