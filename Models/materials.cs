using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSE_DEPARTMENT.Models
{
    public partial class materials
    {
        [Key]
        public int materials_id { get; set; }
        public int? subject_id { get; set; }
        public int? year_id { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string materials_topic { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string arranged_by { get; set; }
        public string reference { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        [DataType(DataType.Date)]
        public System.DateTime publish_date { get; set; }
        public string specification { get; set; }

        [ForeignKey("subject_id")]

        public virtual Subject Subject { get; set; }

        [ForeignKey("year_id")]
        public virtual Year Year { get; set; }
    }
}