using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuardianReviews.Domain.Model
{
    /// <summary>
    /// This class is just here to get an Id primary key on the join table
    /// </summary>
    public class MusicReviewsToMusicTypes
    {
        public virtual int Id { get; set; }
    }
}
