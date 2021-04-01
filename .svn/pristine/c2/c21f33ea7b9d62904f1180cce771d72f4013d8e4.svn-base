using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseCONSQLParameterMap : ClassMap<CONSQLParameter>
    {
        public BaseCONSQLParameterMap()
        {
            Table("CONSQLParameters");
            Id(x => x.Id).Column("SQLParameterId").GeneratedBy.Native(builder => builder.AddParam("sequence", "CONSQLParameterSEQ"));

            Map(x => x.Name).Column("Name").Not.Nullable().Length(30);

            Map(x => x.IsDate).Column("IsDate").Not.Nullable();

            Map(x => x.DateValue).Column("DateValue").Nullable();

            Map(x => x.DefaultDateValue).Column("DefaultDateValue").Nullable();

            Map(x => x.IsInt).Column("IsInt").Not.Nullable();

            Map(x => x.Int32Value).Column("Int32Value").Nullable();

            Map(x => x.IsString).Column("IsString").Not.Nullable();

            Map(x => x.StringValue).Column("StringValue").Nullable().Length(100);

            Map(x => x.Secuence).Column("Secuence").Not.Nullable();

            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

            Map(x => x.SQLId).Column("SQLId").Not.Nullable();

        }
    }
}