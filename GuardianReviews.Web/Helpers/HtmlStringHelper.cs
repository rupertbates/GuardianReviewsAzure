using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuardianReviews.Web.Helpers
{
    public static class HtmlStringHelper
    {
        public static HtmlString Html(this string str)
        {
            return new HtmlString(str);
        }
    }
}