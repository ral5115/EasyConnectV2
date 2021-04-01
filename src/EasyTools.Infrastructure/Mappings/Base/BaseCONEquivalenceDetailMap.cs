using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseCONEquivalenceDetailMap : ClassMap<CONEquivalenceDetail>
    {
        public BaseCONEquivalenceDetailMap()
        {
            Table("CONEquivalenceDetails");
            Id(x => x.Id).Column("EquivalenceDetailId").GeneratedBy.Native(builder => builder.AddParam("sequence", "CONEquivalenceDetailSEQ"));

            Map(x => x.Code).Column("Code").Not.Nullable().Length(50);

            Map(x => x.Name).Column("Name").Not.Nullable().Length(50);

            Map(x => x.Value1).Column("Value1").Nullable().Length(50);

            Map(x => x.Value2).Column("Value2").Nullable().Length(50);

            Map(x => x.Value3).Column("Value3").Nullable().Length(50);

            Map(x => x.Value4).Column("Value4").Nullable().Length(50);

            Map(x => x.Value5).Column("Value5").Nullable().Length(50);

            Map(x => x.Value6).Column("Value6").Nullable().Length(50);

            Map(x => x.Value7).Column("Value7").Nullable().Length(50);

            Map(x => x.Value8).Column("Value8").Nullable().Length(50);

            Map(x => x.Value9).Column("Value9").Nullable().Length(50);

            Map(x => x.Value10).Column("Value10").Nullable().Length(50);

            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            Map(x => x.EquivalenceId).Column("EquivalenceId").Not.Nullable();

        }
    }
}