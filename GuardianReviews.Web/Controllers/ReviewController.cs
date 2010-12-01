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
            var reviews = _repository.FindAll(r => r.ReviewType.DisplayName == reviewType.DisplayName || reviewType == ReviewTypes.Unknown,
                new QueryOptions<Review>
                {
                    Take=10, 
                    OrderDirection= OrderByDirection.Descending, 
                    OrderBySelector = r => r.PublicationDate
                });
            return View(reviews);
        }

    }
}
