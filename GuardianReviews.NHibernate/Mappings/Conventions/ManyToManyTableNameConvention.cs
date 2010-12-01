using FluentNHibernate.Conventions.Inspections;

namespace GuardianReviews.NHibernate.Mappings.Conventions
{
    public class ManyToManyTableNameConvention : FluentNHibernate.Conventions.ManyToManyTableNameConvention
    {
        protected override string GetBiDirectionalTableName(IManyToManyCollectionInspector collection,
            IManyToManyCollectionInspector otherSide)
        {

            return Inflector.Net.Inflector.Pluralize(collection.EntityType.Name) + "To" +
                Inflector.Net.Inflector.Pluralize(otherSide.EntityType.Name);
        }

        protected override string GetUniDirectionalTableName(IManyToManyCollectionInspector collection)
        {
            return Inflector.Net.Inflector.Pluralize(collection.EntityType.Name) + "To" +
                Inflector.Net.Inflector.Pluralize(collection.ChildType.Name);
        }
    }
}
