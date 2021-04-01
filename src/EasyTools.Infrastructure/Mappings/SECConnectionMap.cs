using EasyTools.Infrastructure.Mappings.Base;

namespace EasyTools.Infrastructure.Mappings
{
    public class SECConnectionMap : BaseSECConnectionMap
    {
        public SECConnectionMap() : base()
        {
            References(x => x.Company).Column("CompanyId").Not.Insert().Not.Update();

        }
    }
}