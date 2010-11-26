using FluentNHibernate.Automapping.Alterations;
using GuardianReviews.Domain.Model;

namespace GuardianReviews.NHibernate.Mappings
{
    public class MusicReviewOverride : IAutoMappingOverride<MusicReview>
    {
        #region IAutoMappingOverride<TenderDocument> Members

        public void Override(FluentNHibernate.Automapping.AutoMapping<MusicReview> mapping)
        {
            mapping.HasManyToMany(m => m.MusicTypes)
                .Cascade.All()
                .AsBag();
        }

        #endregion
    }
}
