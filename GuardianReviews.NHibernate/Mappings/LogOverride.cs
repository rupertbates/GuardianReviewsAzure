using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping.Alterations;
using KableDirect.Ted.Reports.Model;

namespace KableDirect.Ted.Reports.Database.Mappings
{
    public class LogOverride : IAutoMappingOverride<Log>
    {
        #region IAutoMappingOverride<Log> Members

        public void Override(FluentNHibernate.Automapping.AutoMapping<Log> mapping)
        {
            mapping.Map(l => l.Context).Length(512);
            mapping.Map(l => l.Level).Length(512);
            mapping.Map(l => l.Logger).Length(512);
            mapping.Map(l => l.Message).Length(4000);
            mapping.Map(l => l.Exception).Length(10000);
        }

        #endregion
    }
}
