using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuardianReviews.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.AcceptTypes != null && Request.AcceptTypes.Contains("application/xrds+xml"))
            {
                Response.ContentType = "application/xrds+xml";
                ViewData["OPIdentifier"] = true;
                return View("Xrds");
            }
            ViewModel.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
