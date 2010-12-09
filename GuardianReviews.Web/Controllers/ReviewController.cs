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
    public class ReviewController : Controller
    {
        private readonly IQueryRepository<Review> _repository;

        public ReviewController(IQueryRepository<Review> repository)
        {
            _repository = repository;
        }
        
        public ActionResult Index(ReviewTypes reviewType)
        {
            var options = new QueryOptions<Review>
            {
                Take = 12,
                OrderDirection = OrderByDirection.Descending,
                OrderBySelector = r => r.PublicationDate
            };

            IList<Review> reviews;
            if (reviewType == ReviewTypes.Unknown)
                reviews = _repository.FindAll(r => r.ReviewType != ReviewTypes.Unknown, options);
            else
                reviews = _repository.FindAll(r => r.ReviewType == reviewType, options);
            return View(reviews);
        }
        public ActionResult View(int id)
        {
            return View(_repository.Get(id));
        }
        
    }
}
