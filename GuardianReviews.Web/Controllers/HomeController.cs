using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuardianReviews.ApplicationServices;
using GuardianReviews.Domain.BaseClasses;
using GuardianReviews.Domain.Interfaces;
using GuardianReviews.Domain.Model;

namespace GuardianReviews.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQueryRepository<Review> _repository;
        private readonly IUserService _userService;

        public HomeController(IQueryRepository<Review> repository, IUserService userService)
        {
            _userService = userService;
            _repository = repository;
        }

        public ActionResult Index()
        {
            if (IsXrdsRequest())
                return View("Xrds");

            IList<Review> reviews;
            var queryOptions = new QueryOptions<Review>
                                   {
                                       Take = 12,
                                       OrderDirection = OrderByDirection.Descending,
                                       OrderBySelector = r => r.PublicationDate
                                   };

            var user = _userService.GetCurrentUser();            
            if(user != null)
                reviews = _repository.FindAll(r =>  user.IsSubscribedTo(r.ReviewType), queryOptions);
            else
                reviews = _repository.FindAll(queryOptions);

            return View(reviews);
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
