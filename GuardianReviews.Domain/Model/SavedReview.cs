using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;

namespace GuardianReviews.Domain.Model
{
    public class SavedReview : Entity
    {
        public virtual Review Review { get; set; }
        public virtual DateTime DateAdded { get; set; }
        public virtual int? UserStarRating { get; set; }
    }
}
