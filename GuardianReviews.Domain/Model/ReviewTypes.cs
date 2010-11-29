using System.Collections.Generic;
using GuardianReviews.Domain.BaseClasses;

namespace GuardianReviews.Domain.Model
{
    public class ReviewTypes : Enumeration
    {
        public static readonly ReviewTypes Film = new ReviewTypes(0, "Film");
        public static readonly ReviewTypes Music = new ReviewTypes(0, "Music");
        public static readonly ReviewTypes Books = new ReviewTypes(0, "Books");
        public static readonly ReviewTypes Theatre = new ReviewTypes(0, "Theatre");
        public static readonly ReviewTypes Game = new ReviewTypes(0, "Game");
        public static readonly ReviewTypes TvAndRadio = new ReviewTypes(0, "Tv and Radio");
        public static readonly ReviewTypes Unknown = new ReviewTypes(0, "Unknown");
        private ReviewTypes(int id, string displayName)
        {
            Id = id;
            DisplayName = displayName;
        }
        public ReviewTypes()
        {
            Reviews = new List<Review>();
        }

        public virtual IList<Review> Reviews { get; private set; }
    }
}
