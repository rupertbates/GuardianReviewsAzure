using System.Collections.Generic;

namespace GuardianReviews.Domain.Model
{
    public class MusicReview : Review
    {
        public MusicReview()
        {
            MusicTypes = new List<MusicTypes>();
        }
        public virtual IList<MusicTypes> MusicTypes { get; set; }
    }
}
