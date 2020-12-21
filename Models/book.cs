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
        public string book_name { get; set; }
        public string book_author { get; set; }
        public string specification { get; set; }
        public string edition { get; set; }
        public int? subject_id { get; set; }

      
        [ForeignKey("year_id")]
        public virtual Year Year { get; set; }
        [ForeignKey("subject_id")]
        public virtual Subject Subject { get; set; }
    }
}