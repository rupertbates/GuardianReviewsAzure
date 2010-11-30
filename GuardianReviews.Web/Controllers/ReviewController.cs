using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuardianReviews.Domain.Interfaces;
using GuardianReviews.Domain.Model;

namespace GuardianReviews.Web.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IRepository<Review> _repository;

        public ReviewController(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View(_repository.Select());
        }

    }
}
