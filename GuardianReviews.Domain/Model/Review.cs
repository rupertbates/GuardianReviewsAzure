using System;
using SharpArch.Core.DomainModel;

namespace GuardianReviews.Domain.Model
{
    public class Review : Entity
    {
        protected Review()
        {
        }
        public Review(ReviewTypes type)
        {
            ReviewType = type;
        }
        public virtual int Id { get; protected set; }
        public virtual string Title { get; set; }
        public virtual string StandFirst { get; set; }
        public virtual string TrailText { get; set; }
        public virtual string Body { get; set; }
        public virtual DateTime PublicationDate { get; set; }
        public virtual ReviewTypes ReviewType { get; protected set; }
        public virtual int? StarRating { get; set; }
        public virtual string WebUrl { get; set; }
    }
}