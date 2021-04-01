using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseCONSQLDetailMap : ClassMap<CONSQLDetail>
    {
        public BaseCONSQLDetailMap()
        {
            Table("CONSQLDetails");
            Id(x => x.Id).Column("SQLDetailId").GeneratedBy.Native(builder => builder.AddParam("sequence", "CONSQLDetailSEQ"));

            Map(x => x.Field).Column("Field").Not.Nullable().Length(30);

            Map(x => x.Description).Column("Description").Nullable().Length(100);

            Map(x => x.Secuence).Column("Secuence").Not.Nullable();

            Map(x => x.DBType).Column("DBType").Not.Nullable().Length(100);

            Map(x => x.DefaultValue).Column("DefaultValue").Nullable().Length(255);

            Map(x => x.EquivalenceColumnId).Column("EquivalenceColumnId").Nullable();

            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

            Map(x => x.EquivalenceId).Column("EquivalenceId").Nullable();

            //Map(x => x.MainSQLDetailId).Column("MainSQLDetailId").Nullable();

            Map(x => x.SQLId).Column("SQLId").Not.Nullable();

            Map(x => x.StructureDetailId).Column("StructureDetailId").Nullable();

        }
    }
}