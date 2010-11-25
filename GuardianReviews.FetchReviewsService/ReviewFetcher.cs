using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guardian.OpenPlatform;
using GuardianReviews.Domain;
using GuardianReviews.Domain.Interfaces;

namespace GuardianReviews.FetchReviewsService
{
    class ReviewFetcher
    {
        private readonly OpenPlatformSearch _contentApi;
        private IRepository<Review> _repository;

        public ReviewFetcher(OpenPlatformSearch contentApi)
        {
            _contentApi = contentApi;
        }

        public void FetchReviews()
        {
            FetchReviews(DateTime.Today.AddDays(-7)); //anything in the last week
        }
        public void FetchReviews(DateTime from)
        {
            var results = _contentApi.ContentSearch(new ContentSearchParameters
            {
                Tags = new List<string> { "tone/reviews" },  //reviews only
                From = from,
                PageSize = 50
            });
        }
    }
}
