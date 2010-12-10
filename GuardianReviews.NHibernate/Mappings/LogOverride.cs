using FluentNHibernate.Automapping.Alterations;
using GuardianReviews.Domain.Model;

namespace GuardianReviews.NHibernate.Mappings
{
    public class LogOverride : IAutoMappingOverride<Log>
    {
        #region IAutoMappingOverride<Log> Members

        public void Override(FluentNHibernate.Automapping.AutoMapping<Log> mapping)
        {
            mapping.Table("Log");
            mapping.Map(l => l.Context).Length(512);
            mapping.Map(l => l.Level).Length(512);
            mapping.Map(l => l.Logger).Length(512);
            mapping.Map(l => l.Message).Length(4000);
            mapping.Map(l => l.Exception).Length(10000);
        }

        #endregion
    }
}
