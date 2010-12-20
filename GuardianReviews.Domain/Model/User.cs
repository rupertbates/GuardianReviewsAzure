using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Iesi.Collections.Generic;
//using Iesi.Collections.Generic;
using SharpArch.Core;
using SharpArch.Core.DomainModel;

namespace GuardianReviews.Domain.Model
{
    public class User : Entity
    {
        public User()
        {
            
            ExcludedReviewTypes = new List<ReviewTypes>();
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
        public virtual IList<ReviewTypes> ExcludedReviewTypes { get; protected set; }
        public virtual bool IsSubscribedTo(ReviewTypes reviewType)
        {
            if (reviewType == ReviewTypes.Unknown)
                return false;
            return !ExcludedReviewTypes.Any(r => r.Id == reviewType.Id);
        }
        public virtual void SaveReviewToList(Review review)
        {
            SavedReviews.Add(new SavedReview {Review = review, DateAdded = DateTime.Now});
        }
        public virtual void RemoveReviewFromList(SavedReview review)
        {
            //Check.Ensure(SavedReviews.Contains(review), "Tried to remove a rev");
            SavedReviews.Remove(review);
        }
        public virtual void UnsubscribeFrom(ReviewTypes reviewType)
        {
            ExcludedReviewTypes.Add(reviewType);
        }
        
    }
}
