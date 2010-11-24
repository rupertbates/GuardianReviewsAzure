using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GuardianReviews.Domain.Enumerations;

namespace GuardianReviews.Domain
{
    public class MusicReview : Review
    {
        public MusicTypes MusicType { get; set; }
    }
}
