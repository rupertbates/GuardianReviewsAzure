using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;

namespace GuardianReviews.NHibernate.Mappings.Conventions
{
    public class JoinedSubclassTableNameConvention : IJoinedSubclassConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IJoinedSubclassInstance instance)
        {
            instance.Table(Inflector.Net.Inflector.Pluralize(instance.EntityType.Name));
        }
    } 
}
