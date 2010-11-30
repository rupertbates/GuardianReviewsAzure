using System;
using System.Collections.Generic;
using System.Linq;
using Guardian.Configuration;
using Guardian.OpenPlatform;
using Guardian.OpenPlatform.Results.SearchResponses;
using GuardianReviews.Domain;
using GuardianReviews.Domain.Interfaces;
using GuardianReviews.Domain.Model;
using GuardianReviews.OpenPlatform.ContentConverters;

namespace GuardianReviews.OpenPlatform
{
    public class ReviewFetcher
    {
        private readonly OpenPlatformSearch _contentApi;
        private readonly int _apiPageSize = ConfigurationHelper.GetConfigValueOrDefault("ApiPageSize", 50);
        public ReviewFetcher(OpenPlatformSearch contentApi)
        {
            _contentApi = contentApi;
        }
        public IEnumerable<Review> FetchReviews()
        {
            return FetchReviews(DateTime.Today.AddDays(-7)); //anything in the last week
        }
        public IEnumerable<Review> FetchReviews(DateTime from)
        {
            var response = FetchReviews(from, 1);
            if(response.Pages <= 1)
                return response.Results.AsReviews().ToList();

            var results = response.Results.AsEnumerable();
            var numberOfPages = response.Pages;
            for(int pageIndex = 2;pageIndex <= numberOfPages;pageIndex++)
            {
                response = FetchReviews(from, pageIndex);
                results = results.Concat(response.Results);
            }
            return results.AsReviews().ToList();
        }
        
        private ContentSearchResponse FetchReviews(DateTime from, int page)
        {
            var response = _contentApi.ContentSearch(new ContentSearchParameters
            {
                TagFilter = new List<string> { "tone/reviews" },  //reviews only
                ShowFields=new List<string>{"all"},
                ShowTags = new List<string> { "all" },
                From = from,
                PageSize = _apiPageSize,
                PageIndex = page

            });
            return response;
        }
    }
}
