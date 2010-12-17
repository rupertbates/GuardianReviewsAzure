using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuardianReviews.NHibernate.Mappings.JoinTables
{
    public class SavedReview
    {
        public virtual int Id { get; set; }
        public virtual DateTime DateAdded { get; set; }
        
        public virtual int UserStarRating { get; set; }
    }
}
