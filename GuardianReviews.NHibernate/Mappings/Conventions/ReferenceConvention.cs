using FluentNHibernate.Conventions;

namespace GuardianReviews.NHibernate.Mappings.Conventions
{
    public class ReferenceConvention : IReferenceConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IManyToOneInstance instance)
        {
            instance.Column(instance.Property.Name + "Id");
        }
    }
}
