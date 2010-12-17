using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Iesi.Collections.Generic;
//using Iesi.Collections.Generic;
using SharpArch.Core.DomainModel;

namespace GuardianReviews.Domain.Model
{
    public class User : Entity
    {
        public User()
        {
            
            ExcludedReviewTypes = new HashSet<ReviewTypes>();
            SavedReviews = new HashSet<SavedReview> ();
        }
        public virtual string ClaimedIdentifier { get; set; }
        public virtual string FriendlyIdentifier { get; set; }
        public virtual string FullName { get; set; }
        public virtual string Email { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string OpenIdProvider { get; set; }
        public virtual string OpenIdProviderVersion { get; set; }
        public virtual ICollection<SavedReview> SavedReviews { get; protected set; }
        public virtual ICollection<ReviewTypes> ExcludedReviewTypes { get; protected set; }
        public virtual bool IsSubscribedTo(ReviewTypes reviewType)
        {
            return !ExcludedReviewTypes.Contains(reviewType);
        }
        public virtual void SaveReviewToList(Review review)
        {
            SavedReviews.Add(new SavedReview {Review = review, DateAdded = DateTime.Now});
        }
        
    }
}
