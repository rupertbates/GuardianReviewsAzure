using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guardian.OpenPlatform.Results.Entities;
using Guardian.OpenPlatform.Results.SearchResponses;
using GuardianReviews.Domain;
using GuardianReviews.Domain.Model;

namespace GuardianReviews.OpenPlatform.ContentConverters
{
    public static class SearchResultConverter
    {
        
        public static IEnumerable<Review> AsReviews(this ContentSearchResponse response)
        {
            return response.Results.Select(AsReview);
        }
        public static Review AsReview(this Content content)
        {
            Review review = null;
            var contentType = content.GetReviewType();
            switch(contentType)
            {
                case ReviewTypes.Music:
                    review = new MusicReview();
                    ((MusicReview)review).MusicTypes = content.GetMusicTypes();
                    break;
            }
            return review;
        }
    }
}
