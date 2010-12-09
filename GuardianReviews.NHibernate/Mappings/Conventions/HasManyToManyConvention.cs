using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace GuardianReviews.NHibernate.Mappings.Conventions
{
    public class HasManyToManyConvention : IHasManyToManyConvention
    {
        public void Apply(IManyToManyCollectionInstance instance)
        {
            //instance.Key.Columns. Column("Id");
            
            //instance.Key.Column(instance.EntityType.Name + "Id");
            
            //instance.Relationship.Column();
            instance.Cascade.SaveUpdate();
        }

        }
}
