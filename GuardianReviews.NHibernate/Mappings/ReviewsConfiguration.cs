using System;
using FluentNHibernate.Automapping;
using GuardianReviews.Domain.Model;

namespace GuardianReviews.NHibernate.Mappings
{
    public class ReviewsConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.Namespace == typeof(MusicReview).Namespace;
        }
    }
}
