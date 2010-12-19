using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GuardianReviews.Domain.Model;

namespace GuardianReviews.Web.Models
{
    public class MenuItemViewModel
    {
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Css { get; set; }
        public bool Closeable { get; set; }
    }
}