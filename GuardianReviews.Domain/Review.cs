using System;
using GuardianReviews.Domain.Enumerations;

namespace GuardianReviews.Domain
{
    public class Review
    {
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }

        public ReviewTypes ReviewType { get; set; }
        public StarRatings? StarRating { get; set; }

    }
}
