using FluentNHibernate.Automapping.Alterations;
using GuardianReviews.Domain.Model;

namespace GuardianReviews.NHibernate.Mappings
{
    public class ReviewOverride : IAutoMappingOverride<Review>
    {
        public void Override(FluentNHibernate.Automapping.AutoMapping<Review> mapping)
        {
            mapping.Map(l => l.Body).Length(10000);    
        }

        
    }
}
