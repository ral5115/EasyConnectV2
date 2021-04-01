using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseCONSQLSendMap : ClassMap<CONSQLSend>
    {
        public BaseCONSQLSendMap()
        {
            Table("CONSQLSends");
            Id(x => x.Id).Column("CONSQLSendId").GeneratedBy.Native(builder => builder.AddParam("sequence", "CONSQLSendSEQ"));

            Map(x => x.Active).Column("Active").Not.Nullable();

            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

            Map(x => x.CONIntegratorConfigurationId).Column("CONIntegratorConfigurationId").Not.Nullable();

            Map(x => x.SQLId).Column("SQLId").Not.Nullable();

        }
    }
}