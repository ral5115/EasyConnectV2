using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseCONEquivalenceMap : ClassMap<CONEquivalence>
    {
        public BaseCONEquivalenceMap()
        {
            Table("CONEquivalences");
            Id(x => x.Id).Column("EquivalenceId").GeneratedBy.Native(builder => builder.AddParam("sequence", "CONEquivalenceSEQ"));
            Map(x => x.Name).Column("Name").Not.Nullable().Length(50);
            Map(x => x.Active).Column("Active").Not.Nullable();
            Map(x => x.LabelValue1).Column("LabelValue1").Nullable().Length(50);
            Map(x => x.LabelValue2).Column("LabelValue2").Nullable().Length(50);
            Map(x => x.LabelValue3).Column("LabelValue3").Nullable().Length(50);
            Map(x => x.LabelValue4).Column("LabelValue4").Nullable().Length(50);
            Map(x => x.LabelValue5).Column("LabelValue5").Nullable().Length(50);
            Map(x => x.LabelValue6).Column("LabelValue6").Nullable().Length(50);
            Map(x => x.LabelValue7).Column("LabelValue7").Nullable().Length(50);
            Map(x => x.LabelValue8).Column("LabelValue8").Nullable().Length(50);
            Map(x => x.LabelValue9).Column("LabelValue9").Nullable().Length(50);
            Map(x => x.LabelValue10).Column("LabelValue10").Nullable().Length(50);
            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);
            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();
            Map(x => x.CompanyId).Column("CompanyId").Not.Nullable();

        }
    }
}