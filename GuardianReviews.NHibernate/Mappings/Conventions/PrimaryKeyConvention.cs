using FluentNHibernate.Conventions;

namespace GuardianReviews.NHibernate.Mappings.Conventions
{
    public class PrimaryKeyConvention : IIdConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IIdentityInstance instance)
        {
            instance.Column("Id");
            //instance.UnsavedValue("0");
            //instance.GeneratedBy.HiLo("1000");
        }
    }
}
