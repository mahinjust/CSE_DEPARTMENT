using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSE_DEPARTMENT.Models
{
    public partial class book
    {
        [Key]
        public int book_id { get; set; }
        public int? year_id { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string book_name { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string book_author { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string specification { get; set; }

        public string edition { get; set; }
        public int? subject_id { get; set; }


        [ForeignKey("year_id")]
        public virtual Year Year { get; set; }
        [ForeignKey("subject_id")]
        public virtual Subject Subject { get; set; }

        public IEnumerable<HttpPostedFileBase> files { get; set; }
        //[Required(ErrorMessage = "This Is A Required Field!!")]
        //public string File { get; set; }
        //public long? Size { get; set; }
        //public string Type { get; set; }
    }
}