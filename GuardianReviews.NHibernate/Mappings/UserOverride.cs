using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using GuardianReviews.Domain.Model;

namespace GuardianReviews.NHibernate.Mappings
{
    public class UserOverride : IAutoMappingOverride<User>
    {
        public void Override(AutoMapping<User> mapping)
        {
            mapping
                .HasMany(u => u.SavedReviews)
                .AsSet()
                //.Table("UserListItems")
                .Cascade.All();
            mapping
                .HasManyToMany(u => u.ExcludedReviewTypes)
                .AsSet()
                .Table("UserExcludedReviewTypes")
                .Cascade.All();
        }
    }
}
