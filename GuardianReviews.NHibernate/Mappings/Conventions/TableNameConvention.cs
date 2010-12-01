using FluentNHibernate.Conventions;

namespace GuardianReviews.NHibernate.Mappings.Conventions
{
    public class TableNameConvention : IClassConvention
    {
        public bool Accept(IClassConventionAcceptance acceptance)
        {
            return true;
        }
        public void Apply(FluentNHibernate.Conventions.Instances.IClassInstance instance)
        {
            instance.Table(Inflector.Net.Inflector.Pluralize(instance.EntityType.Name));
        }
    }
}
