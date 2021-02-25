using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CSE_DEPARTMENT.Models
{
    public partial class notice
    {
        [Key]
        public int notice_id { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string notice_upload { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string notice_topic { get; set; }
        
        public string published_by { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        [DataType(DataType.Date)]
        public System.DateTime publish_date { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string created_by { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        [DataType(DataType.Date)]
        public System.DateTime created_date { get; set; }

        public string updated_by { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime updated_date { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        [DataType(DataType.Date)]
        public string deadline { get; set; }
        [Required(ErrorMessage = "This Is A Required Field!!")]
        public string priority { get; set; }
        public string specification { get; set; }
    }
}