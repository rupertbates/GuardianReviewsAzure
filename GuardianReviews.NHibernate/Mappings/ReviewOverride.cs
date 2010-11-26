using FluentNHibernate.Automapping.Alterations;
using GuardianReviews.Domain.Model;

namespace GuardianReviews.NHibernate.Mappings
{
    public class ReviewOverride : IAutoMappingOverride<Review>
    {
        public void Override(FluentNHibernate.Automapping.AutoMapping<Review> mapping)
        {
            mapping.Map(x => x.ReviewType).CustomType<int>();
        }

        
    }
}
