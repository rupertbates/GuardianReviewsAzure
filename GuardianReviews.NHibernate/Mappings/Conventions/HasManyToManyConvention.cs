using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace GuardianReviews.NHibernate.Mappings.Conventions
{
    public class HasManyToManyConvention : IHasManyToManyConvention
    {
        public void Apply(IManyToManyCollectionInstance instance)
        {
            instance.Cascade.SaveUpdate();
        }
    }
}
