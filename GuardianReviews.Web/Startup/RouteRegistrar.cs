using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using GuardianReviews.ApplicationServices;
namespace GuardianReviews.Web.Startup
{
    public class RouteRegistrar
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Reviews", // Route name
                "review/{reviewType}", // URL with parameters
                new { controller = "Review", action = "Index", reviewType = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                "DefaultWithFormat", // Route name
                "{controller}/{action}/{format}", // URL with parameters
                new { controller = "Home", action = "Index", format = UrlParameter.Optional }, // Parameter defaults
                new { format = new UrlEnumMatchConstraint(typeof(HttpResponseTypes)) }
            );
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                
            );
            routes.MapRoute(
                "DefaultWithIdAndFormat", // Route name
                "{controller}/{action}/{id}/{format}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional, format = UrlParameter.Optional }, // Parameter defaults
                new { format = new UrlEnumMatchConstraint(typeof(HttpResponseTypes)) }
            );
            
        }
    }
}