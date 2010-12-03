using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuardianReviews.Domain.BaseClasses;
using GuardianReviews.Domain.Interfaces;
using GuardianReviews.Domain.Model;

namespace GuardianReviews.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQueryRepository<Review> _repository;

        public HomeController(IQueryRepository<Review> repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            if (IsXrdsRequest())
                return View("Xrds");
            
            var reviews = _repository.FindAll(
                new QueryOptions<Review>
                {
                    Take = 10,
                    OrderDirection = OrderByDirection.Descending,
                    OrderBySelector = r => r.PublicationDate
                });

            return View(reviews);

            return View();
        }
        /// <summary>
        /// Handles relying party discovery per OpenID 2.0.
        /// It allows Providers to call back to the relying party site to confirm the
        /// identity that it is claiming in the realm and return_to URLs.
        /// This page should be pointed to by the 'realm' home page, which in this site
        /// is HomeController.Index
        /// </summary>
        /// <returns></returns>
        private bool IsXrdsRequest()
        {
            if(Request.AcceptTypes != null && Request.AcceptTypes.Contains("application/xrds+xml"))
            {
                Response.ContentType = "application/xrds+xml";
                return true;
            }
            return false;

        }
        public ActionResult About()
        {
            return View();
        }
    }
}
