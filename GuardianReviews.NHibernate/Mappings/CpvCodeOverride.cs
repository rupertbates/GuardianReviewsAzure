using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using KableDirect.Ted.Reports.Model;

namespace KableDirect.Ted.Reports.Database.Mappings
{
    public class CpvCodeOverride: IAutoMappingOverride<CpvCode>
    {
        public void Override(AutoMapping<CpvCode> mapping)
        {
            mapping.Id(t => t.Code)
                .GeneratedBy.Assigned();
            mapping.HasManyToMany(cp => cp.Tenders)
                //.Table("CpvCodesToTenders")
                //.ParentKeyColumn("CpvCodeId")
                //.ChildKeyColumn("TenderDocumentId")
                .Cascade.All()
                .Inverse()
                .AsBag();
        }
        
    }
}
