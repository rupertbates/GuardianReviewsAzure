using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guardian.OpenPlatform.Results.Entities;
using Guardian.OpenPlatform.Results.SearchResponses;
using GuardianReviews.Domain;

namespace GuardianReviews.FetchReviewsService
{
    public class ContentConverter
    {
        public IEnumerable<Review> ConvertSearchResults(ContentSearchResponse searchResults)
        {
            return searchResults.Results.Select(c => c);
        }
        protected Review ConvertSearchResult(Content c)
        {
            Review r = null;
            switch(c.SectionId)
            {
                case "music":
                    r = new MusicReview();
                    ((MusicReview)r).MusicType = GetMusicType
            }
        }
    }
}
