using System;
using System.Collections.Generic;
using Guardian.OpenPlatform;
using GuardianReviews.Domain;
using GuardianReviews.Domain.Interfaces;
using GuardianReviews.Domain.Model;

namespace GuardianReviews.OpenPlatform
{
    public class ReviewFetcher
    {
        private readonly OpenPlatformSearch _contentApi;
        private IRepository<Review> _repository;

        public ReviewFetcher(OpenPlatformSearch contentApi, IRepository<Review> repository)
        {
            _contentApi = contentApi;
            _repository = repository;
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
            //_repository.Insert();
        }
    }
}
