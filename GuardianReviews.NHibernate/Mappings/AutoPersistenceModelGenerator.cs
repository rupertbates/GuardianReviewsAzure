using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using GuardianReviews.Domain.Model;
using GuardianReviews.NHibernate.Mappings.Conventions;
using SharpArch.Core.DomainModel;
using SharpArch.Data.NHibernate.FluentNHibernate;
using ForeignKeyConvention = GuardianReviews.NHibernate.Mappings.Conventions.ForeignKeyConvention;
using ManyToManyTableNameConvention = GuardianReviews.NHibernate.Mappings.Conventions.ManyToManyTableNameConvention;

namespace GuardianReviews.NHibernate.Mappings
{

    public class AutoPersistenceModelGenerator : IAutoPersistenceModelGenerator
    {

        #region IAutoPersistenceModelGenerator Members

        public AutoPersistenceModel Generate()
        {
            return AutoMap.AssemblyOf<Review>(new AutomappingConfiguration())
                .Conventions.Setup(GetConventions())
                //.IgnoreBase<Entity>()
                //.IgnoreBase(typeof(EntityWithTypedId<>))
                .UseOverridesFromAssemblyOf<AutoPersistenceModelGenerator>();
        }

        #endregion

        private Action<IConventionFinder> GetConventions()
        {
            return c =>
            {
                //c.Add<ForeignKeyConvention>();
                c.Add<HasManyConvention>();
                c.Add<HasManyToManyConvention>();
                c.Add<ManyToManyTableNameConvention>();
                //c.Add<PrimaryKeyConvention>();
                c.Add<ReferenceConvention>();
                c.Add<TableNameConvention>();
                c.Add<JoinedSubclassTableNameConvention>();
            };
        }
    }
}
