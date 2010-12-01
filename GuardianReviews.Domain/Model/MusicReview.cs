using System.Collections.Generic;

namespace GuardianReviews.Domain.Model
{
    public class MusicReview : Review
    {
        protected MusicReview()
        {
            ReviewType = ReviewTypes.Music;
        }
        public MusicReview(IList<MusicTypes> types)
        {
            ReviewType = ReviewTypes.Music;
            MusicTypes = types;
        }
        public virtual IList<MusicTypes> MusicTypes { get; protected set; }
    }
}
