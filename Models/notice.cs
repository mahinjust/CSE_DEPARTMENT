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
        public string notice_upload { get; set; }
        public string notice_topic { get; set; }
        public string published_by { get; set; }
        public System.DateTime publish_date { get; set; }
        public string created_by { get; set; }
        public System.DateTime created_date { get; set; }
        public string updated_by { get; set; }
        public System.DateTime updated_date { get; set; }
        public string deadline { get; set; }
        public string priority { get; set; }
        public string specification { get; set; }
    }
}