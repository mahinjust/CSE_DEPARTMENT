using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSE_DEPARTMENT.Models;
using CSE_DEPARTMENT.ViewModel;

namespace CSE_DEPARTMENT.ViewModel
{
    public class Multipledata
    {
        public IEnumerable<AspNetUser> AspNetUser { get; set; }

        public IEnumerable<AspNetRole> AspNetRole { get; set; }
    }
}