using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseSECConnectionMap : ClassMap<SECConnection>
    {
        public BaseSECConnectionMap()
        {
            Table("SECConnections");
            Id(x => x.Id).Column("ConnectionId").GeneratedBy.Native(builder => builder.AddParam("sequence", "SECConnectionSEQ"));

            Map(x => x.Active).Column("Active").Not.Nullable();

            Map(x => x.Login).Column("Login").Not.Nullable().Length(50);

            Map(x => x.Password).Column("Password").Not.Nullable().Length(255);

            Map(x => x.Service).Column("Service").Not.Nullable().Length(50);

            Map(x => x.DB).Column("DB").Nullable().Length(50);

            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            Map(x => x.Name).Column("Name").Not.Nullable().Length(50);

            Map(x => x.CompanyId).Column("CompanyId").Not.Nullable();

            Map(x => x.DbType).Column("DbType").Length(10).Not.Nullable();

        }
    }
}