using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using GuardianReviews.Domain.Model;

namespace GuardianReviews.NHibernate.Mappings
{
    //public class MusicType
    //{
    //    public virtual MusicTypes MusicType { get; set; }
    //}
    public class MusicTypeMap :ClassMap<MusicReview>
    {
       
        public MusicTypeMap()
        {
            Map()
        }
    }
}
