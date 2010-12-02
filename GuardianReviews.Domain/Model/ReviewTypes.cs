using System.Collections.Generic;
using GuardianReviews.Domain.BaseClasses;
using SharpArch.Core.DomainModel;

namespace GuardianReviews.Domain.Model
{
    public class ReviewTypes : Enumeration
    {
        public static readonly ReviewTypes Film = new ReviewTypes(1, "Film");
        public static readonly ReviewTypes Music = new ReviewTypes(2, "Music");
        public static readonly ReviewTypes Books = new ReviewTypes(3, "Books");
        public static readonly ReviewTypes Theatre = new ReviewTypes(4, "Theatre");
        public static readonly ReviewTypes Game = new ReviewTypes(5, "Game");
        public static readonly ReviewTypes TvAndRadio = new ReviewTypes(6, "TvAndRadio", "Television & Radio");
        public static readonly ReviewTypes Unknown = new ReviewTypes(7, "Unknown", "Unknown", false);
        
        protected ReviewTypes(int id, string name):this(id, name, name, true)
        {
        }
        protected ReviewTypes(int id, string name, string displayName): this(id, name, displayName, true)
        {
        }
        protected ReviewTypes(int id, string name, string displayName, bool showInUI):base(id, name, displayName, showInUI)
        {
        }
        public ReviewTypes()
        {
            Reviews = new List<Review>();
        }

        public virtual IList<Review> Reviews { get; private set; }
    }
}
