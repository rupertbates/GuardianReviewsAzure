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
            var reviewType = content.GetReviewType();

            if(reviewType == ReviewTypes.Music)
                review = new MusicReview(content.GetMusicTypes());
            else //TODO: might get rid of this, if we don't know what type it is we should probably skip it.    
                review = new Review(reviewType);

            PopulateReview(content, ref review);
            return review;
        }
        private static void PopulateReview(Content content, ref Review review)
        {
            review.PublicationDate = content.WebPublicationDate;
            review.StarRating = content.GetStarRating();
            review.Title = content.WebTitle;
            review.WebUrl = content.WebUrl;
        }
    }
}
