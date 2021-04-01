using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseSECCompanyMap : ClassMap<SECCompany>
    {
        public BaseSECCompanyMap()
        {
            Table("SECCompanies");
            Id(x => x.Id).Column("CompanyId").GeneratedBy.Native(builder => builder.AddParam("sequence", "SECCompanySEQ"));

            Map(x => x.IdentificationNumer).Column("IdentificationNumer").Not.Nullable().Length(20);

            Map(x => x.TradeName).Column("TradeName").Not.Nullable().Length(50);

            Map(x => x.Active).Column("Active").Not.Nullable();

            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            Map(x => x.EmailServer).Column("EmailServer").Not.Nullable().Length(100);

            Map(x => x.EmailUser).Column("EmailUser").Not.Nullable().Length(100);

            Map(x => x.EmailPassword).Column("EmailPassword").Not.Nullable().Length(100);

            Map(x => x.EmailPort).Column("EmailPort").Not.Nullable().Length(10);

            Map(x => x.EmailEnableSSL).Column("EmailEnableSSL").Not.Nullable();

        }
    }
}