using EasyTools.Infrastructure.Mappings.Base;

namespace EasyTools.Infrastructure.Mappings
{
    public class SECUserCompanyMap : BaseSECUserCompanyMap
    {
        public SECUserCompanyMap() : base()
        {
            References(x => x.Company).Column("CompanyId").Not.Insert().Not.Update();

            References(x => x.User).Column("UserId").Not.Insert().Not.Update();

        }
    }
}