using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseCONStructureDetailMap : ClassMap<CONStructureDetail>
    {
        public BaseCONStructureDetailMap()
        {
            Table("CONStructureDetails");
            Id(x => x.Id).Column("StructureDetailId").GeneratedBy.Native(builder => builder.AddParam("sequence", "CONStructureDetailSEQ"));

            Map(x => x.Field).Column("Field").Not.Nullable().Length(30);

            Map(x => x.Description).Column("Description").Nullable().Length(255);

            Map(x => x.DBType).Column("DBType").Not.Nullable();

            Map(x => x.Observations).Column("Observations").Nullable().Length(500);

            Map(x => x.IsRequired).Column("IsRequired").Not.Nullable();

            Map(x => x.Secuence).Column("Secuence").Not.Nullable();

            Map(x => x.InitialPosition).Column("InitialPosition").Nullable();

            Map(x => x.Sizes).Column("Sizes").Nullable();

            Map(x => x.FinalPosition).Column("FinalPosition").Nullable();

            Map(x => x.Visible).Column("Visible").Not.Nullable();

            Map(x => x.DefaultValue).Column("DefaultValue").Nullable().Length(10);

            Map(x => x.Ent).Column("Ent").Not.Nullable();

            Map(x => x.Dec).Column("Dec").Not.Nullable();

            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

            Map(x => x.StructureId).Column("StructureId").Not.Nullable();

        }
    }
}