using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseSECUserCompanyMap : ClassMap<SECUserCompany>
    {
        public BaseSECUserCompanyMap()
        {
            Table("SECUserCompanies");
            Id(x => x.Id).Column("UserCustomerId").GeneratedBy.Native(builder => builder.AddParam("sequence", "SECUserCompanySEQ"));

            Map(x => x.Active).Column("Active").Not.Nullable();

            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

            Map(x => x.CompanyId).Column("CompanyId").Not.Nullable();

            Map(x => x.UserId).Column("UserId").Not.Nullable();

        }
    }
}