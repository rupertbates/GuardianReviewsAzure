using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guardian.OpenPlatform;

namespace GuardianReviews.FetchReviewsService
{
    class ReviewFetcher
    {
        private readonly OpenPlatformSearch _contentApi;

        public ReviewFetcher(OpenPlatformSearch contentApi)
        {
            _contentApi = contentApi;
        }

        public void FetchReviews()
        {
            var results = _contentApi.ContentSearch(new ContentSearchParameters
                                          {
                                              Tags = new List<string> { "tone/reviews" },  //reviews only
                                              From = DateTime.Today.AddDays(-7), //anything in the last week
                                              PageSize = 50
                                          });
        }
    }
}
